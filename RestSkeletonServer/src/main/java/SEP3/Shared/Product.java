package SEP3.Shared;

public class Product
{
    private String title;
    private int id;
    private String url;
    private String size;

    public Product(int id, String title, String url, String size)
    {
        this.id = id;
        this.title = title;
        this.url = url;
        this.size = size;
    }

    public Product(){};

    public int getId()
    {
        return id;
    }

    public void setId(int id)
    {
        this.id = id;
    }

    public String getTitle()
    {
        return title;
    }

    public void setTitle(String title)
    {
        this.title = title;
    }

    public String getUrl()
    {
        return url;
    }

    public void setUrl(String url)
    {
        this.url = url;
    }

    public String getSize()
    {
        return size;
    }

    public void setSize(String size)
    {
        this.size = size;
    }
}
