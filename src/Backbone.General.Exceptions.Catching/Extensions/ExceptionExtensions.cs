using Backbone.General.Exceptions.Catching.Models;

namespace Backbone.General.Exceptions.Catching.Extensions;

/// <summary>
/// Contains extensions for operations to wrap by try catch
/// </summary>
public static class ExceptionExtensions
{
    /// <summary>
    /// Invokes the function and returns result based on function success.
    /// </summary>
    /// <param name="func">The function to invoke.</param>
    /// <returns>A <see cref="FuncResult{T}"/> representing the success or failure of the function invocation.</returns>
    public static async ValueTask<FuncResult<bool>> GetValueAsync(this Func<Task> func)
    {
        FuncResult<bool> result;

        try
        {
            await func();
            result = new FuncResult<bool>(true);
        }
        catch (Exception e)
        {
            result = new FuncResult<bool>(e);
        }

        return result;
    }

    /// <summary>
    /// Invokes the function and returns function result.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <param name="func">The asynchronous function to invoke.</param>
    /// <returns>A <see cref="FuncResult{T}"/> representing the result of the function invocation.</returns>
    public static async ValueTask<FuncResult<T>> GetValueAsync<T>(this Func<Task<T>> func)
    {
        FuncResult<T> result;

        try
        {
            result = new FuncResult<T>(await func());
        }
        catch (Exception e)
        {
            result = new FuncResult<T>(e);
        }

        return result;
    }

    /// <summary>
    /// Invokes the function and returns result.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <param name="func">The asynchronous function to invoke that returns a ValueTask of T.</param>
    /// <returns>A <see cref="FuncResult{T}"/> representing the result of the function invocation.</returns>
    public static async ValueTask<FuncResult<T>> GetValueAsync<T>(this Func<ValueTask<T>> func)
    {
        FuncResult<T> result;

        try
        {
            result = new FuncResult<T>(await func());
        }
        catch (Exception e)
        {
            result = new FuncResult<T>(e);
        }

        return result;
    }

    /// <summary>
    ///  Invokes the function and returns result based on function success.
    /// </summary>
    /// <param name="func">The asynchronous action to invoke that returns a ValueTask.</param>
    /// <returns>A <see cref="FuncResult{bool}"/> representing the success or failure of the function invocation.</returns>
    public static async ValueTask<FuncResult<bool>> GetValueAsync(this Func<ValueTask> func)
    {
        FuncResult<bool> result;

        try
        {
            await func();
            result = new FuncResult<bool>(true);
        }
        catch (Exception e)
        {
            result = new FuncResult<bool>(e);
        }

        return result;
    }

    /// <summary>
    /// Invokes the function and returns result.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <param name="func">The function to invoke.</param>
    /// <returns>A <see cref="FuncResult{T}"/> representing the result of the function invocation.</returns>
    public static FuncResult<T> GetValue<T>(this Func<T> func)
    {
        FuncResult<T> result;

        try
        {
            result = new FuncResult<T>(func());
        }
        catch (Exception e)
        {
            result = new FuncResult<T>(e);
        }

        return result;
    }
}