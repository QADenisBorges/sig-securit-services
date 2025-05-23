using FluentResults;

namespace Sig.SecurityService.Tenant.Common.FluentResults;

public static class ResultExtensions
{
    public static TOutput FromResult<T, TOutput>(
       this Result<T> result,
       Func<T, TOutput> onSuccess,
       Func<List<IError>, TOutput> onFailure)
    {
        return result.IsSuccess
            ? onSuccess(result.Value)
            : onFailure(result.Errors);
    }

    public static Result<TOut> Match<TIn, TOut>(
    this Result<TIn> result,
    Func<TIn, TOut> onSuccess,
    Func<IReadOnlyCollection<IError>, IError, Result<TOut>> onFailure)
    {
        return result.IsSuccess
            ? Result.Ok(onSuccess(result.Value))
            : onFailure(
                result.Errors,
                result.Errors.FirstOrDefault() ?? new Error("Unknown error") 
            );
    }

    public static TOutput MatchResult<T, TOutput>(
      this Result<T> result,
      Func<T, TOutput> onSuccess,
      Func<List<IError>, TOutput> onFailure)
    {
        return result.IsSuccess
            ? onSuccess(result.Value)
            : onFailure(result.Errors);
    }

    public static Result<TOut> Match<TOut>(
    this Result result,
    Func<Result<TOut>> onSuccess,
    Func<IReadOnlyCollection<IError>, Result<TOut>> onFailure)
    {
        return result.IsSuccess
            ? onSuccess()
            : onFailure(result.Errors);
    }

    public static Result<TOut> Match<TIn, TOut>(
        this Result<TIn> result,
        Func<TIn, TOut> onSuccess,
        Func<IReadOnlyCollection<IError>, Result<TOut>> onFailure)
    {
        return result.IsSuccess
            ? Result.Ok(onSuccess(result.Value))
            : onFailure(result.Errors);
    }

    public static Result<TOut> Match<TIn, TOut>(
    this Result<TIn> result,
    Func<TIn, Result<TOut>> onSuccess,
    Func<IReadOnlyCollection<IError>, Result<TOut>> onFailure)
    {
        return result.IsSuccess
            ? onSuccess(result.Value)
            : onFailure(result.Errors);
    }

    public static async Task<Result<TOut>> MatchAsync<TIn, TOut>(
        this Result<TIn> result,
        Func<TIn, Task<Result<TOut>>> onSuccess,
        Func<IReadOnlyCollection<IError>, Result<TOut>> onFailure)
    {
        return result.IsSuccess
            ? await onSuccess(result.Value)
            : onFailure(result.Errors);
    }

    public static Result<TOut> IfFailure<TOut>(
    this Result result,
    Func<IReadOnlyCollection<IError>, Result<TOut>> onFailure)
    {
        return result.IsSuccess
            ? Result.Ok<TOut>(default!)
            : onFailure(result.Errors);
    }

    public static Result<TOut> IfFailure<TIn, TOut>(
        this Result<TIn> result,
        Func<IReadOnlyCollection<IError>, Result<TOut>> onFailure)
    {
        return result.IsSuccess
            ? Result.Ok<TOut>(default!)
            : onFailure(result.Errors);
    }

    public static Result<TOut> IfSuccess<TOut>(
    this Result result,
    Func<Result<TOut>> onSuccess)
    {
        return result.IsSuccess
            ? onSuccess()
            : Result.Fail<TOut>(result.Errors);
    }

    public static Result<TOut> IfSuccess<TIn, TOut>(
        this Result<TIn> result,
        Func<TIn, Result<TOut>> onSuccess)
    {
        return result.IsSuccess
            ? onSuccess(result.Value)
            : Result.Fail<TOut>(result.Errors);
    }

    public static async Task<Result<TOut>> IfSuccessAsync<TIn, TOut>(
        this Result<TIn> result,
        Func<TIn, Task<Result<TOut>>> onSuccess)
    {
        return result.IsSuccess
            ? await onSuccess(result.Value)
            : Result.Fail<TOut>(result.Errors);
    }
}
