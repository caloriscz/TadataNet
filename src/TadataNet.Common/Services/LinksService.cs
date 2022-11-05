using AutoMapper;
using System;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using TadataNet.Common.Entities;
using TadataNet.Common.Helpers;
using TadataNet.Common.Models.Links;
using TadataNet.Common.Models.Tasks;

namespace WebApi.Services;

public interface ILinksService
{
    IEnumerable<LinksResponse> GetAll();
    void Create(CreateLinkRequest createLinkRequest);
    void Update(int id, UpdateLinkRequest model);
    string BackupLinks();
    void Delete(int id);
}

public class LinksService : ILinksService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;


    public LinksService(DataContext context,  IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<LinksResponse> GetAll()
    {
        var links = _context.Links.Join(_context.Urls, link => link.UrlId, url => url.Id, (link, url) => new LinksResponse
        {
            Id = link.Id,
            Url = url.Uri,
            Title = link.Title,
            Description = link.Description,
            DateCreated = link.DateCreated
        });

        var linksResponse = _mapper.Map<IList<LinksResponse>>(links);

        return _mapper.Map<IList<LinksResponse>>(links);
    }

    public void Create(CreateLinkRequest createLinkRequest)
    {
        var link = _mapper.Map<Link>(createLinkRequest);
        link.DateCreated = DateTime.Now;
        link.Account = _context.Accounts.Find(1);

        var url = _context.Urls.FirstOrDefault(x => x.Uri == createLinkRequest.Url);

        if (url is not null)
        {
            link.Url = url;
        }
        else
        {
            link.Url = new Url { Uri = createLinkRequest.Url };

            _context.Urls.Add(link.Url);
            _context.SaveChanges();
        }

        link.Url = _context.Urls.First(x => x.Uri == createLinkRequest.Url);
        _context.Links.Add(link);
        _context.SaveChanges();
    }

    public void Update(int id, UpdateLinkRequest model)
    {
        var link = _context.Links.Find(id);

        // validate
        if (link == null) throw new AppException("Link not found");

        // check if link exists, if not create else update
        var url = _context.Urls.FirstOrDefault(x => x.Uri == model.Url);

        if (url is not null)
        {
            link.Url = url;
        }
        else
        {
            link.Url = new Url { Uri = model.Url };

            _context.Urls.Add(link.Url);
            _context.SaveChanges();
        }

        link.Url = _context.Urls.First(x => x.Uri == model.Url);


        // copy model to account and save
        _mapper.Map(model, link);
        _context.Links.Update(link);
        _context.SaveChanges();
    }

    public string BackupLinks()
    {
        var links = _context.Links.Join(_context.Urls, link => link.UrlId, url => url.Id, (link, url) => new LinkBackup
        {
            Url = url.Uri,
            Title = link.Title,
            Description = link.Description,
        });

        var linksResponse = _mapper.Map<IList<LinkBackup>>(links);

        IList<LinkBackup> linkBackup = _mapper.Map<IList<LinkBackup>>(links);

        return JsonSerializer.Serialize(linkBackup);
    }

    public void Delete(int id)
    {
        var link = _context.Links.Find(id);
        if (link != null)
        {
            _context.Links.Remove(link);
            _context.SaveChanges();
        }
    }
}
