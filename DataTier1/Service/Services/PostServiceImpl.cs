using Data.Interfaces;
using Data.Models;
using Google.Protobuf.WellKnownTypes;
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
    public override async Task<GetPostsResponse> getAllPosts(Empty request, ServerCallContext context)
    {
        ICollection<Post> posts = await _postRepository.GetAll();
        ICollection<GetPostResponse> response = new List<GetPostResponse>();
        foreach (Post post in posts)
        {
            GetPostResponse p = new GetPostResponse()
            {
                Id = post.Id.ToString(),
                Author = post.AuthorId.ToString(),
                Content = post.Content,
                Title = post.Title,
                Date = post.CreationDate.ToString(),
                EventId = post.EventId.ToString(),
                AuthorName = post.Author.Username,
            };
            response.Add(p);
        }
        GetPostsResponse getPostsResponse = new GetPostsResponse();
        getPostsResponse.Posts.Add(response);
        return getPostsResponse;
    }
    public override async Task<GetPostsResponse> getAllPostsByAuthorId(GetRequest request, ServerCallContext context)
    {
        ICollection<Post> posts = await _postRepository.GetByAsync(e=>e.AuthorId.Equals(request.Id));
        ICollection<GetPostResponse> response = new List<GetPostResponse>();
        foreach (Post post in posts)
        {
            GetPostResponse p = new GetPostResponse()
            {
                Id = post.Id.ToString(),
                Author = post.AuthorId.ToString(),
                Content = post.Content,
                Title = post.Title,
                Date = post.CreationDate.ToString(),
                EventId = post.EventId.ToString(),
                AuthorName = post.Author.Username,
            };
            response.Add(p);
        }
        GetPostsResponse getPostsResponse = new GetPostsResponse();
        getPostsResponse.Posts.Add(response);
        return getPostsResponse;
    }
    public override async Task<GetPostsResponse> getAllPostsByEventId(GetRequest request, ServerCallContext context)
    {
        ICollection<Post> posts = await _postRepository.GetByAsync(e => e.EventId.Equals(request.Id));
        ICollection<GetPostResponse> response = new List<GetPostResponse>();
        foreach (Post post in posts)
        {
            GetPostResponse p = new GetPostResponse()
            {
                Id = post.Id.ToString(),
                Author = post.AuthorId.ToString(),
                Content = post.Content,
                Title = post.Title,
                Date = post.CreationDate.ToString(),
                EventId = post.EventId.ToString(),
                AuthorName = post.Author.Username,
            };
            response.Add(p);
        }
        GetPostsResponse getPostsResponse = new GetPostsResponse();
        getPostsResponse.Posts.Add(response);
        return getPostsResponse;
    }
}