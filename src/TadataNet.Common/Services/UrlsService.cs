using AutoMapper;
using TadataNet.Common.Entities;
using TadataNet.Common.Helpers;
using TadataNet.Common.Models.Urls;
using TadataNet.Common.Utilities;

namespace TadataNet.Common.Services;

public interface IUrlsService
{
    IEnumerable<UrlsResponse> GetAll();
    void Create(CreateUrlRequest createUrlResponse);
    void Update(int id, UpdateUrlRequest model);
    string CheckLinks();

}

public class UrlsService : IUrlsService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UrlsService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<UrlsResponse> GetAll()
    {
        var urls = _context.Urls;
        return _mapper.Map<IList<UrlsResponse>>(urls);
    }

    public void Create(CreateUrlRequest createUrlRequest)
    {
        // map model to new account object
        var url = _mapper.Map<Url>(createUrlRequest);
        url.DateCreated = DateTime.Now;

        _context.Urls.Add(url);
        _context.SaveChanges();
    }

    public void Update(int id, UpdateUrlRequest model)
    {
        //var tag = _context.Tags.Find(id);

        // validate
        //if (tag == null) throw new AppException("Tag not found");

        // copy model to account and save
        //_mapper.Map(model, tag);
        //_context.Tags.Update(tag);
        //_context.SaveChanges();
    }

    public string CheckLinks()
    {
        var urls = _context.Urls;
        string report = string.Empty;

        foreach (var url in urls)
        {
            bool uri = LinkUtil.CheckLink(url.Uri);

            if (uri)
            {
                report += $"{url.Uri} link exists";
            }
            else
            {
                report += $"{url.Uri} link does not exist";
            }
        }

        return $"report: {report}";
    }
}