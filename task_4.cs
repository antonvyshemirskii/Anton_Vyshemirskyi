namespace StringLibraryTest;

[TestClass]
public class task_4
{
    [TestMethod]
    public void NumberPairsTest1(){
        Assert.AreEqual(4, NumberPairs(new[]{1, 3, 6, 2, 2, 0, 4, 5}));
    }
    [TestMethod]
    public void NumberPairsTest2(){
        Assert.AreEqual(2, NumberPairs(new[]{3, 3, 2, 1, 0, 1, 0}));
    }
    [TestMethod]
    public void NumberPairsTest3(){
        Assert.AreEqual(0, NumberPairs(new[]{100, 3, 100, 1, 0, 1, 0}));
    }

    public static int NumberPairs(int[] arr, int target = 5){
        int numberPairs = 0;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = i + 1; j < arr.Length; j++){
                if(arr[i] + arr[j] == target){
                    numberPairs++;
                }
            }
        }
        return numberPairs;
    }

}