namespace StringLibraryTest;

[TestClass]
public class extra_task_2
{
            
    [TestMethod]
    public void ToIPv4Test1(){
        Assert.AreEqual("128.32.10.1", ToIPv4(2149583361));
    }    
    [TestMethod]
    public void ToIPv4Test2(){
        Assert.AreEqual("0.131.51.15", ToIPv4(2149583));
    }
    [TestMethod]
    public void ToIPv4Test3(){
        Assert.AreEqual("0.0.0.32", ToIPv4(32));
    }
    [TestMethod]
    public void ToIPv4Test4(){
        Assert.AreEqual("0.0.0.0", ToIPv4(0));
    }


    public static string ToIPv4(UInt32 num){
        string numBinary = Convert.ToString(num, 2);
        string IPv = "";
        if(num == 0)
        {
            return "0.0.0.0";
        }
        else if(numBinary.Length > 1 && numBinary.Length < 8)
        { 
            IPv = "0.0.0.";
        }
        else if(numBinary.Length > 8 && numBinary.Length < 16){
            IPv = "0.0.";
        }
        else if(numBinary.Length > 16 && numBinary.Length < 24){
            IPv = "0.";
        }
        
        for (int i = 0; i < numBinary.Length; i+=8)
        {
            if(i+8 >= numBinary.Length){
                IPv += Convert.ToString(Convert.ToInt32(numBinary.Substring(i, numBinary.Length-i), 2), 10);
            }
            else{  
                IPv += Convert.ToString(Convert.ToInt32(numBinary.Substring(i, 8), 2), 10);
                IPv += ".";
            }
        }
        return IPv;
        

    }
}