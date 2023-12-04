using Data.Interfaces;
using Data.Models;
using Grpc.Core;

namespace Service.Services;

public class PostServiceImpl: PostService.PostServiceBase
{
    private readonly ILogger<PostServiceImpl> _logger;
    private readonly IPostRepository _postRepository;
    
    public PostServiceImpl(ILogger<PostServiceImpl> logger, IPostRepository postRepository)
    {
        _logger = logger;
        _postRepository = postRepository;
    }
    
    public override async Task<CreatePostResponse> CreatePost(CreatePostRequest request, ServerCallContext context)
    {
        Post p = new Post()
        {
            Id = Guid.NewGuid(),
            Content = request.Content,
            Title = request.Title
        };
        Post post = await _postRepository.CreateAsync(p);
        CreatePostResponse response = new CreatePostResponse()
        {
            Id = post.Id.ToString(),
            Author = post.AuthorId.ToString(),
            Content = post.Content,
            Title = post.Title
        };
        return response;
    }
}