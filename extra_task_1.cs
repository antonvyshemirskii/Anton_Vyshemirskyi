namespace StringLibraryTest;

[TestClass]
public class extra_task_1
{
     [TestMethod]
    public void NextBiggerTest1(){
        Assert.AreEqual(21, NextBigger(12));
    }
    [TestMethod]
    public void NextBiggerTest2(){
        Assert.AreEqual(2073121, NextBigger(2071321));
    }
    [TestMethod]
    public void NextBiggerTest3(){
        Assert.AreEqual(-1, NextBigger(531));
    }

        public static int NextBigger(int num){

        int[] numArr = num.ToString().Select(o=> Convert.ToInt32(o) - 48 ).ToArray();
        for (int i = numArr.Length - 1; i != 0; i--)
        {
            if(numArr[i-1] < numArr[i]){
                (numArr[i-1], numArr[i]) = (numArr[i], numArr[i-1]);
                return Int32.Parse(string.Join("", numArr));
            }
        }
        return -1;
    }
}