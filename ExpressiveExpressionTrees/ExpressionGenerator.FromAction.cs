﻿using global::System;
using global::System.Linq.Expressions;
namespace ExpressiveExpressionTrees {
#if EXPRESSIVE_EXPRESSION_TREES_ASSEMBLY
    public
#endif
    partial class ExpressionGenerator {
        public Expression FromAction<T1>(Expression<Func<T1>> p1, Expression<Action<T1>> expr)
        {
            return ExpressionReplacer.
                    Search(expr.Body).
                    When(expr.Parameters[0], p1.Body).
                    GetResult();
        }
        public Expression FromAction<T1, T2>(Expression<Func<T1>> p1, Expression<Func<T2>> p2, Expression<Action<T1, T2>> expr)
        {
            return ExpressionReplacer.
                    Search(expr.Body).
                    When(expr.Parameters[0], p1.Body).
                    When(expr.Parameters[1], p2.Body).
                    GetResult();
        }
        public Expression FromAction<T1, T2, T3>(Expression<Func<T1>> p1, Expression<Func<T2>> p2, Expression<Func<T3>> p3, Expression<Action<T1, T2, T3>> expr)
        {
            return ExpressionReplacer.
                    Search(expr.Body).
                    When(expr.Parameters[0], p1.Body).
                    When(expr.Parameters[1], p2.Body).
                    When(expr.Parameters[2], p3.Body).
                    GetResult();
        }
        public Expression FromAction<T1, T2, T3, T4>(Expression<Func<T1>> p1, Expression<Func<T2>> p2, Expression<Func<T3>> p3, Expression<Func<T4>> p4, Expression<Action<T1, T2, T3, T4>> expr)
        {
            return ExpressionReplacer.
                    Search(expr.Body).
                    When(expr.Parameters[0], p1.Body).
                    When(expr.Parameters[1], p2.Body).
                    When(expr.Parameters[2], p3.Body).
                    When(expr.Parameters[3], p4.Body).
                    GetResult();
        }
        public Expression FromAction<T1, T2, T3, T4, T5>(Expression<Func<T1>> p1, Expression<Func<T2>> p2, Expression<Func<T3>> p3, Expression<Func<T4>> p4, Expression<Func<T5>> p5, Expression<Action<T1, T2, T3, T4, T5>> expr)
        {
            return ExpressionReplacer.
                    Search(expr.Body).
                    When(expr.Parameters[0], p1.Body).
                    When(expr.Parameters[1], p2.Body).
                    When(expr.Parameters[2], p3.Body).
                    When(expr.Parameters[3], p4.Body).
                    When(expr.Parameters[4], p5.Body).
                    GetResult();
        }
        public Expression FromAction<T1, T2, T3, T4, T5, T6>(Expression<Func<T1>> p1, Expression<Func<T2>> p2, Expression<Func<T3>> p3, Expression<Func<T4>> p4, Expression<Func<T5>> p5, Expression<Func<T6>> p6, Expression<Action<T1, T2, T3, T4, T5, T6>> expr)
        {
            return ExpressionReplacer.
                    Search(expr.Body).
                    When(expr.Parameters[0], p1.Body).
                    When(expr.Parameters[1], p2.Body).
                    When(expr.Parameters[2], p3.Body).
                    When(expr.Parameters[3], p4.Body).
                    When(expr.Parameters[4], p5.Body).
                    When(expr.Parameters[5], p6.Body).
                    GetResult();
        }
        public Expression FromAction<T1, T2, T3, T4, T5, T6, T7>(Expression<Func<T1>> p1, Expression<Func<T2>> p2, Expression<Func<T3>> p3, Expression<Func<T4>> p4, Expression<Func<T5>> p5, Expression<Func<T6>> p6, Expression<Func<T7>> p7, Expression<Action<T1, T2, T3, T4, T5, T6, T7>> expr)
        {
            return ExpressionReplacer.
                    Search(expr.Body).
                    When(expr.Parameters[0], p1.Body).
                    When(expr.Parameters[1], p2.Body).
                    When(expr.Parameters[2], p3.Body).
                    When(expr.Parameters[3], p4.Body).
                    When(expr.Parameters[4], p5.Body).
                    When(expr.Parameters[5], p6.Body).
                    When(expr.Parameters[6], p7.Body).
                    GetResult();
        }
        public Expression FromAction<T1, T2, T3, T4, T5, T6, T7, T8>(Expression<Func<T1>> p1, Expression<Func<T2>> p2, Expression<Func<T3>> p3, Expression<Func<T4>> p4, Expression<Func<T5>> p5, Expression<Func<T6>> p6, Expression<Func<T7>> p7, Expression<Func<T8>> p8, Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8>> expr)
        {
            return ExpressionReplacer.
                    Search(expr.Body).
                    When(expr.Parameters[0], p1.Body).
                    When(expr.Parameters[1], p2.Body).
                    When(expr.Parameters[2], p3.Body).
                    When(expr.Parameters[3], p4.Body).
                    When(expr.Parameters[4], p5.Body).
                    When(expr.Parameters[5], p6.Body).
                    When(expr.Parameters[6], p7.Body).
                    When(expr.Parameters[7], p8.Body).
                    GetResult();
        }
        public Expression FromAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Func<T1>> p1, Expression<Func<T2>> p2, Expression<Func<T3>> p3, Expression<Func<T4>> p4, Expression<Func<T5>> p5, Expression<Func<T6>> p6, Expression<Func<T7>> p7, Expression<Func<T8>> p8, Expression<Func<T9>> p9, Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> expr)
        {
            return ExpressionReplacer.
                    Search(expr.Body).
                    When(expr.Parameters[0], p1.Body).
                    When(expr.Parameters[1], p2.Body).
                    When(expr.Parameters[2], p3.Body).
                    When(expr.Parameters[3], p4.Body).
                    When(expr.Parameters[4], p5.Body).
                    When(expr.Parameters[5], p6.Body).
                    When(expr.Parameters[6], p7.Body).
                    When(expr.Parameters[7], p8.Body).
                    When(expr.Parameters[8], p9.Body).
                    GetResult();
        }
        public Expression FromAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Func<T1>> p1, Expression<Func<T2>> p2, Expression<Func<T3>> p3, Expression<Func<T4>> p4, Expression<Func<T5>> p5, Expression<Func<T6>> p6, Expression<Func<T7>> p7, Expression<Func<T8>> p8, Expression<Func<T9>> p9, Expression<Func<T10>> p10, Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> expr)
        {
            return ExpressionReplacer.
                    Search(expr.Body).
                    When(expr.Parameters[0], p1.Body).
                    When(expr.Parameters[1], p2.Body).
                    When(expr.Parameters[2], p3.Body).
                    When(expr.Parameters[3], p4.Body).
                    When(expr.Parameters[4], p5.Body).
                    When(expr.Parameters[5], p6.Body).
                    When(expr.Parameters[6], p7.Body).
                    When(expr.Parameters[7], p8.Body).
                    When(expr.Parameters[8], p9.Body).
                    When(expr.Parameters[9], p10.Body).
                    GetResult();
        }
        public Expression FromAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Expression<Func<T1>> p1, Expression<Func<T2>> p2, Expression<Func<T3>> p3, Expression<Func<T4>> p4, Expression<Func<T5>> p5, Expression<Func<T6>> p6, Expression<Func<T7>> p7, Expression<Func<T8>> p8, Expression<Func<T9>> p9, Expression<Func<T10>> p10, Expression<Func<T11>> p11, Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> expr)
        {
            return ExpressionReplacer.
                    Search(expr.Body).
                    When(expr.Parameters[0], p1.Body).
                    When(expr.Parameters[1], p2.Body).
                    When(expr.Parameters[2], p3.Body).
                    When(expr.Parameters[3], p4.Body).
                    When(expr.Parameters[4], p5.Body).
                    When(expr.Parameters[5], p6.Body).
                    When(expr.Parameters[6], p7.Body).
                    When(expr.Parameters[7], p8.Body).
                    When(expr.Parameters[8], p9.Body).
                    When(expr.Parameters[9], p10.Body).
                    When(expr.Parameters[10], p11.Body).
                    GetResult();
        }
        public Expression FromAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Expression<Func<T1>> p1, Expression<Func<T2>> p2, Expression<Func<T3>> p3, Expression<Func<T4>> p4, Expression<Func<T5>> p5, Expression<Func<T6>> p6, Expression<Func<T7>> p7, Expression<Func<T8>> p8, Expression<Func<T9>> p9, Expression<Func<T10>> p10, Expression<Func<T11>> p11, Expression<Func<T12>> p12, Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> expr)
        {
            return ExpressionReplacer.
                    Search(expr.Body).
                    When(expr.Parameters[0], p1.Body).
                    When(expr.Parameters[1], p2.Body).
                    When(expr.Parameters[2], p3.Body).
                    When(expr.Parameters[3], p4.Body).
                    When(expr.Parameters[4], p5.Body).
                    When(expr.Parameters[5], p6.Body).
                    When(expr.Parameters[6], p7.Body).
                    When(expr.Parameters[7], p8.Body).
                    When(expr.Parameters[8], p9.Body).
                    When(expr.Parameters[9], p10.Body).
                    When(expr.Parameters[10], p11.Body).
                    When(expr.Parameters[11], p12.Body).
                    GetResult();
        }
        public Expression FromAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Expression<Func<T1>> p1, Expression<Func<T2>> p2, Expression<Func<T3>> p3, Expression<Func<T4>> p4, Expression<Func<T5>> p5, Expression<Func<T6>> p6, Expression<Func<T7>> p7, Expression<Func<T8>> p8, Expression<Func<T9>> p9, Expression<Func<T10>> p10, Expression<Func<T11>> p11, Expression<Func<T12>> p12, Expression<Func<T13>> p13, Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> expr)
        {
            return ExpressionReplacer.
                    Search(expr.Body).
                    When(expr.Parameters[0], p1.Body).
                    When(expr.Parameters[1], p2.Body).
                    When(expr.Parameters[2], p3.Body).
                    When(expr.Parameters[3], p4.Body).
                    When(expr.Parameters[4], p5.Body).
                    When(expr.Parameters[5], p6.Body).
                    When(expr.Parameters[6], p7.Body).
                    When(expr.Parameters[7], p8.Body).
                    When(expr.Parameters[8], p9.Body).
                    When(expr.Parameters[9], p10.Body).
                    When(expr.Parameters[10], p11.Body).
                    When(expr.Parameters[11], p12.Body).
                    When(expr.Parameters[12], p13.Body).
                    GetResult();
        }
        public Expression FromAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Expression<Func<T1>> p1, Expression<Func<T2>> p2, Expression<Func<T3>> p3, Expression<Func<T4>> p4, Expression<Func<T5>> p5, Expression<Func<T6>> p6, Expression<Func<T7>> p7, Expression<Func<T8>> p8, Expression<Func<T9>> p9, Expression<Func<T10>> p10, Expression<Func<T11>> p11, Expression<Func<T12>> p12, Expression<Func<T13>> p13, Expression<Func<T14>> p14, Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> expr)
        {
            return ExpressionReplacer.
                    Search(expr.Body).
                    When(expr.Parameters[0], p1.Body).
                    When(expr.Parameters[1], p2.Body).
                    When(expr.Parameters[2], p3.Body).
                    When(expr.Parameters[3], p4.Body).
                    When(expr.Parameters[4], p5.Body).
                    When(expr.Parameters[5], p6.Body).
                    When(expr.Parameters[6], p7.Body).
                    When(expr.Parameters[7], p8.Body).
                    When(expr.Parameters[8], p9.Body).
                    When(expr.Parameters[9], p10.Body).
                    When(expr.Parameters[10], p11.Body).
                    When(expr.Parameters[11], p12.Body).
                    When(expr.Parameters[12], p13.Body).
                    When(expr.Parameters[13], p14.Body).
                    GetResult();
        }
        public Expression FromAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Expression<Func<T1>> p1, Expression<Func<T2>> p2, Expression<Func<T3>> p3, Expression<Func<T4>> p4, Expression<Func<T5>> p5, Expression<Func<T6>> p6, Expression<Func<T7>> p7, Expression<Func<T8>> p8, Expression<Func<T9>> p9, Expression<Func<T10>> p10, Expression<Func<T11>> p11, Expression<Func<T12>> p12, Expression<Func<T13>> p13, Expression<Func<T14>> p14, Expression<Func<T15>> p15, Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> expr)
        {
            return ExpressionReplacer.
                    Search(expr.Body).
                    When(expr.Parameters[0], p1.Body).
                    When(expr.Parameters[1], p2.Body).
                    When(expr.Parameters[2], p3.Body).
                    When(expr.Parameters[3], p4.Body).
                    When(expr.Parameters[4], p5.Body).
                    When(expr.Parameters[5], p6.Body).
                    When(expr.Parameters[6], p7.Body).
                    When(expr.Parameters[7], p8.Body).
                    When(expr.Parameters[8], p9.Body).
                    When(expr.Parameters[9], p10.Body).
                    When(expr.Parameters[10], p11.Body).
                    When(expr.Parameters[11], p12.Body).
                    When(expr.Parameters[12], p13.Body).
                    When(expr.Parameters[13], p14.Body).
                    When(expr.Parameters[14], p15.Body).
                    GetResult();
        }
        public Expression FromAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Expression<Func<T1>> p1, Expression<Func<T2>> p2, Expression<Func<T3>> p3, Expression<Func<T4>> p4, Expression<Func<T5>> p5, Expression<Func<T6>> p6, Expression<Func<T7>> p7, Expression<Func<T8>> p8, Expression<Func<T9>> p9, Expression<Func<T10>> p10, Expression<Func<T11>> p11, Expression<Func<T12>> p12, Expression<Func<T13>> p13, Expression<Func<T14>> p14, Expression<Func<T15>> p15, Expression<Func<T16>> p16, Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> expr)
        {
            return ExpressionReplacer.
                    Search(expr.Body).
                    When(expr.Parameters[0], p1.Body).
                    When(expr.Parameters[1], p2.Body).
                    When(expr.Parameters[2], p3.Body).
                    When(expr.Parameters[3], p4.Body).
                    When(expr.Parameters[4], p5.Body).
                    When(expr.Parameters[5], p6.Body).
                    When(expr.Parameters[6], p7.Body).
                    When(expr.Parameters[7], p8.Body).
                    When(expr.Parameters[8], p9.Body).
                    When(expr.Parameters[9], p10.Body).
                    When(expr.Parameters[10], p11.Body).
                    When(expr.Parameters[11], p12.Body).
                    When(expr.Parameters[12], p13.Body).
                    When(expr.Parameters[13], p14.Body).
                    When(expr.Parameters[14], p15.Body).
                    When(expr.Parameters[15], p16.Body).
                    GetResult();
        }
    }
}
