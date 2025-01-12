//C#/.NET MVC Challenges

//Challenge 1: Create a Model

public class Comment
{
    public int Id { get; set; }         // Unique identifier for the comment
    public string Content { get; set; } // The content of the comment
    public int PostId { get; set; }     // Foreign key referencing the post
    public int UserId { get; set; }     // Foreign key referencing the user

    // Optional: Navigation properties (if using Entity Framework)
    public virtual Post Post { get; set; }
    public virtual User User { get; set; }
}

//Challenge 2: LINQ Query
public List<Comment> GetCommentsForPost(int postId)
{
    var comments = _context.Comments
                           .Where(c => c.PostId == postId)
                           .ToList();
    return comments;
}

// Challenge 3: AJAX Call
function submitComment(postId, userId, content) {
    const data = {
        PostId: postId,
        UserId: userId,
        Content: content
    };

    fetch('/Comments/Create', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
    .then(response => {
        if (response.ok) {
            return response.json();
        } else {
            throw new Error('Failed to submit comment.');
        }
    })
    .then(data => {
        console.log('Comment submitted successfully:', data);
    })
    .catch(error => {
        console.error('Error:', error);
    });
}