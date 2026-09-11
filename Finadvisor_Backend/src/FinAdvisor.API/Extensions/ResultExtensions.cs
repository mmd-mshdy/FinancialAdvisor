using FinAdvisor.BuildingBlocks.Domain.Results;

namespace FinAdvisor.API.Extensions;

public static class ResultExtensions
{
    public static IResult ToProblem(
        this Result result)
    {
        if (result.IsSuccess)
        {
            throw new InvalidOperationException(
                "Cannot create a problem response from a successful result.");
        }

        return result.Error.Type switch
        {
            ErrorType.Validation =>
                Results.Problem(
                    statusCode:
                        StatusCodes.Status400BadRequest,
                    title:
                        result.Error.Code,
                    detail:
                        result.Error.Description),

            ErrorType.NotFound =>
                Results.Problem(
                    statusCode:
                        StatusCodes.Status404NotFound,
                    title:
                        result.Error.Code,
                    detail:
                        result.Error.Description),

            ErrorType.Conflict =>
                Results.Problem(
                    statusCode:
                        StatusCodes.Status409Conflict,
                    title:
                        result.Error.Code,
                    detail:
                        result.Error.Description),

            ErrorType.Unauthorized =>
                Results.Problem(
                    statusCode:
                        StatusCodes.Status401Unauthorized,
                    title:
                        result.Error.Code,
                    detail:
                        result.Error.Description),

            ErrorType.Forbidden =>
                Results.Problem(
                    statusCode:
                        StatusCodes.Status403Forbidden,
                    title:
                        result.Error.Code,
                    detail:
                        result.Error.Description),

            _ =>
                Results.Problem(
                    statusCode:
                        StatusCodes.Status500InternalServerError,
                    title:
                        result.Error.Code,
                    detail:
                        result.Error.Description)
        };
    }
}