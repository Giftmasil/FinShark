using System;
using api.Dtos.Comment;
using api.Models;

namespace api.Mappers;

public static class CommentMapper
{
    public static CommentDto ToCommentDto(this Comment commentModel)
    {
        return new CommentDto(
            commentModel.Id,
            commentModel.Title,
            commentModel.Content,
            commentModel.CreatedOn,
            commentModel.StockId
        );
    }
}
