using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Tags;

namespace WebApi.Services;

public interface ITagsService
{
    IEnumerable<TagsResponse> GetAll();
    void Create(CreateTagRequest createTagResponse);
    void Update(int id, UpdateTagRequest model);
}

public class TagsService : ITagsService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public TagsService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<TagsResponse> GetAll()
    {
        var tags = _context.Tags;
        return _mapper.Map<IList<TagsResponse>>(tags);
    }

    public void Create(CreateTagRequest createTagResponse)
    {
        var tag = _mapper.Map<Tag>(createTagResponse);

        _context.Tags.Add(tag);
        _context.SaveChanges();
    }

    public void Update(int id, UpdateTagRequest model)
    {
        var tag = _context.Tags.Find(id);

        // validate
        if (tag == null) throw new AppException("Tag not found");

        // copy model to account and save
        //_mapper.Map(model, tag);
        //_context.Tags.Update(tag);
        //_context.SaveChanges();
    }
}