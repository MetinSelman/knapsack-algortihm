using System;

public class SırtÇantası
{
    static int SırtÇantasıProblemi(int kapasite, int[] ağırlıklar, int[] değerler, int öğeSayısı)
    {
        // dp dizisini oluşturma ve başlatma
        int[] dp = new int[kapasite + 1];

        for (int i = 1; i < öğeSayısı + 1; i++)//bu for döngüsü 1 den başlayarak ağırlık ve değerlerini sırasıyla almamızı sağlıyor
        {
            for (int w = kapasite; w >= 0; w--)//bu for döngüsü ise ağırlıkların olup olamayacağını hesaplamak için kullanılıyor.
            {

                if (ağırlıklar[i - 1] <= w)
                {
                    // Maksimum değeri bulma (Math.Max olmadan)
                    int dahil = dp[w - ağırlıklar[i - 1]] + değerler[i - 1];
                    //dahil kısmına değeri ekliyoruz ve bunu yaparken önceki değeri de toplamak için önceden eklediğimiz değer dp[] dizisinde durduğu için oradan dp[] nin o indisindeki değerle beraber topluyoruz
                    int dahilDegil = dp[w];
                    // dahil değil kısmı ise bir önceki en büyük değerler toplamını içeriyor
                    if (dahil > dahilDegil)
                    {
                        dp[w] = dahil;
                        //eğer bu dahil kısmı bir önceki en büyük değerden büyükse yeni en büyük değer olarak dp[w] ye atılıyor
                    }
                    else
                    {
                        dp[w] = dahilDegil;
                    }
                }
            }
        }
        // Sırt çantasının maksimum değerini döndürme
        return dp[kapasite];
    }

    // Ana kod
    public static void Main(String[] args)
    {
        int[] karlar = { 40, 30, 50, 10 }; // Eşyaların değerleri
        int[] ağırlıklar = { 15, 12, 25, 28 }; // Eşyaların ağırlıkları
        int kapasite = 39;
        int öğeSayısı = karlar.Length;
        Console.Write(SırtÇantasıProblemi(kapasite, ağırlıklar, karlar, öğeSayısı));
    }
}


public class SırtÇantasırecursive
{

    // A utility function that returns the maximum of two integers
    static int Maksimum(int a, int b)
    {
        if (a > b) return a;
        else
        {
            return b;
        }
        
    }

    // Returns the maximum value that can be put in a knapsack of capacity kapasite
    static int SırtÇantasıProblemi(int kapasite, int[] ağırlıklar, int[] karlar, int öğeSayısı)
    {
        // Base Case
        if (öğeSayısı == 0 || kapasite == 0)
            return 0;

        // If weight of the nth item is more than Knapsack capacity kapasite, then this item cannot be included in the optimal solution
        if (ağırlıklar[öğeSayısı - 1] > kapasite)
            return SırtÇantasıProblemi(kapasite, ağırlıklar, karlar, öğeSayısı - 1);

        // Return the maximum of two cases: 
        // (1) nth item included 
        // (2) not included
        else
            return Maksimum(karlar[öğeSayısı - 1] + SırtÇantasıProblemi(kapasite - ağırlıklar[öğeSayısı - 1], ağırlıklar, karlar, öğeSayısı - 1),//ilk döndürülen bu değer çantaya dahil edilen durum
                            SırtÇantasıProblemi(kapasite, ağırlıklar, karlar, öğeSayısı - 1));//ikinci döndürülen değer ise çantaya dahil eilmeyen durum
    }

    // Main method
    public static void Main()
    {
        int[] karlar = { 40, 30, 50, 10 }; // Eşyaların değerleri
        int[] ağırlıklar = { 15, 12, 25, 28 }; // Eşyaların ağırlıkları
        int kapasite = 39;
        int öğeSayısı = karlar.Length;

        Console.WriteLine(SırtÇantasıProblemi(kapasite, ağırlıklar, karlar, öğeSayısı));
    }
}

