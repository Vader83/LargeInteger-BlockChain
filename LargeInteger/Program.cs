using System.Numerics;

BigInteger GetQuantityOfUniqueKey(int bitsCount) => BigInteger.Pow(new BigInteger(2), bitsCount);

BigInteger GetRandomBigInteger(int bitsCount) 
{
    const int bitInByte = 8;
    byte[] bits = new byte[bitsCount / bitInByte];

    Random random = new Random((int)DateTime.Now.Ticks);
    random.NextBytes(bits);

    return new BigInteger(bits);
}

void Task1()
{
    const int startValue = 8;
    const int endValue = 4096;
    const int baseBit = 2;

    for (int bitLength = startValue; bitLength <= endValue; bitLength *= baseBit)
    {
        Console.WriteLine($"bit bitLength: {bitLength}; unique keys quantity: {GetQuantityOfUniqueKey(bitLength)}");
    }
}

void Task2()
{
    const int startValue = 8;
    const int endValue = 64;
    const int baseBit = 2;

    for (int bitLength = startValue; bitLength <= endValue; bitLength *= baseBit)
    {
        Console.WriteLine($"bit bitLength: {bitLength}; value: {GetRandomBigInteger(bitLength)}");
    }
}

void Task3()
{

}

//Task1();
//Task2();
Task3();