namespace api.Dtos.Comment;

public record class CommentDto
(
    int Id,
    string Title,
    string Content,
    DateTime CreatedOn,
    int? StockId
);
