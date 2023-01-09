namespace WebAPI;

public class Tests
{
    private Client client;

    private string LocalFilePath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "./myfile.txt");
    private string FileName = "myfile.txt";

    [SetUp]
    public void Setup()
    {
        client = new Client();
    }

    [Test, Order(1)]
    public async Task TestUpload()
    {
        var res = await client.UploadFile(LocalFilePath, FileName);
        Assert.AreEqual(System.Net.HttpStatusCode.OK, res.StatusCode);
        Assert.AreEqual(true, res.Data.is_downloadable);
    }

    [Test, Order(2)]
    public async Task TestGetMetadata()
    {
        var res = await client.GetFileMetadata("/myfile.txt");
        Assert.AreEqual(System.Net.HttpStatusCode.OK, res.StatusCode);
        Assert.AreEqual("myfile.txt", res.Data.name);
    }

    [Test, Order(3)]
    public async Task TestDelete()
    {
        var res = await client.DeleteFile("/myfile.txt");
        Assert.AreEqual(System.Net.HttpStatusCode.OK, res.StatusCode);
        Assert.AreEqual(true, res.Data.metadata.is_downloadable);
    }

    [TearDown]
    public void TearDown()
    {
        client.Dispose();
    }

}