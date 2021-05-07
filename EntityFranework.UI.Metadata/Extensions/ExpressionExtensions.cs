using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using JetBrains.Annotations;

namespace EntityFramework.UI.Internal
{
	public static class ExpressionExtensions
	{

		public static MemberInfo GetMemberAccess(this LambdaExpression memberAccessExpression)
		{
			var parameterExpression = memberAccessExpression.Parameters[0];
			var memberInfo = parameterExpression.MatchSimpleMemberAccess(memberAccessExpression.Body);

			if (memberInfo == null)
			{

			}

			var declaringType = memberInfo.DeclaringType;
			var parameterType = parameterExpression.Type;

			if (declaringType != null
				&& declaringType != parameterType
				&& declaringType.IsInterface
				&& declaringType.IsAssignableFrom(parameterType)
				&& memberInfo is PropertyInfo propertyInfo)
			{
				var propertyGetter = propertyInfo.GetMethod;
				var interfaceMapping = parameterType.GetTypeInfo().GetRuntimeInterfaceMap(declaringType);
				var index = Array.FindIndex(interfaceMapping.InterfaceMethods, p => p.Equals(propertyGetter));
				var targetMethod = interfaceMapping.TargetMethods[index];
				foreach (var runtimeProperty in parameterType.GetRuntimeProperties())
				{
					if (targetMethod.Equals(runtimeProperty.GetMethod))
					{
						return runtimeProperty as MemberInfo;
					}
				}
			}

			return memberInfo;
		}

		public static MemberInfo? MatchSimpleMemberAccess(
		   [NotNull] this Expression parameterExpression,
		   [NotNull] Expression memberAccessExpression)
		{
			var memberInfos = MatchMemberAccess(parameterExpression, memberAccessExpression);

			return memberInfos?.Count == 1 ? memberInfos[0] : null;
		}

		private static IReadOnlyList<MemberInfo>? MatchMemberAccess(
			this Expression parameterExpression,
			Expression memberAccessExpression)
		{
			var memberInfos = new List<MemberInfo>();

			MemberExpression? memberExpression;
			var unwrappedExpression = RemoveTypeAs(RemoveConvert(memberAccessExpression));
			do
			{
				memberExpression = unwrappedExpression as MemberExpression;

				if (!(memberExpression?.Member is MemberInfo memberInfo))
				{
					return null;
				}

				memberInfos.Insert(0, memberInfo);

				unwrappedExpression = RemoveTypeAs(RemoveConvert(memberExpression.Expression));
			}
			while (unwrappedExpression != parameterExpression);

			return memberInfos;
		}

		/// <summary>
		///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
		///     the same compatibility standards as public APIs. It may be changed or removed without notice in
		///     any release. You should only use it directly in your code with extreme caution and knowing that
		///     doing so can result in application failures when updating to a new Entity Framework Core release.
		/// </summary>
		public static Expression? RemoveTypeAs([CanBeNull] this Expression? expression)
		{
			while (expression?.NodeType == ExpressionType.TypeAs)
			{
				expression = ((UnaryExpression)RemoveConvert(expression)).Operand;
			}

			return expression;
		}

		private static Expression? RemoveConvert(Expression? expression)
		{
			if (expression is UnaryExpression unaryExpression
				&& (expression.NodeType == ExpressionType.Convert
					|| expression.NodeType == ExpressionType.ConvertChecked))
			{
				return RemoveConvert(unaryExpression.Operand);
			}

			return expression;
		}
	}
}
