namespace StringLibraryTest;

[TestClass]
public class task_3
{
    [TestMethod]
    public void DigitalRootTest1(){
        Assert.AreEqual(7, DigitalRoot(16));
    }
    [TestMethod]
    public void DigitalRootTest2(){
        Assert.AreEqual(6, DigitalRoot(132189));
    }
    [TestMethod]
    public void DigitalRootTest3(){
        Assert.AreEqual(9, DigitalRoot(9));
    }
    
    public static int DigitalRoot(int n){
        if(n < 10){
            return n;
        }
        string nString = n.ToString();
        n = 0;
        foreach(var num in nString){
            n += int.Parse(num.ToString());
        }
        return DigitalRoot(n);  
    }
}