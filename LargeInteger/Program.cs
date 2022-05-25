using System.Numerics;
using System.Diagnostics;

BigInteger GetQuantityOfUniqueKey(int bitsCount) => BigInteger.Pow(new BigInteger(2), bitsCount);

BigInteger GetRandomBigInteger(int bitsCount) 
{
    const bool isUnsigned = true;
    const int bitInByte = 8;
    byte[] bits = new byte[bitsCount / bitInByte];

    Random random = new Random((int)DateTime.Now.Ticks);
    random.NextBytes(bits);
    return new BigInteger(bits, isUnsigned);
}

BigInteger BrutForceKey(BigInteger originalKey)
{
    BigInteger brute = new BigInteger(new byte[originalKey.GetByteCount()]);

    while (!brute.Equals(originalKey)) brute++;

    return brute;
}

TimeSpan GetElapsedTime(Func<BigInteger, BigInteger> func, BigInteger bigInteger)
{
    Stopwatch sw = new Stopwatch();

    sw.Start();
    func(bigInteger);
    sw.Stop();

    return sw.Elapsed;
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
    const int endValue = 4096;
    const int baseBit = 2;

    for (int bitLength = startValue; bitLength <= endValue; bitLength *= baseBit)
    {
        Console.WriteLine($"bit bitLength: {bitLength}; value: {GetRandomBigInteger(bitLength)}");
    }
}

void Task3()
{
    const int startValue = 8;
    const int endValue = 4096;
    const int baseBit = 2;

    for (int bitLength = startValue; bitLength <= endValue; bitLength *= baseBit)
    {
        BigInteger randomBig = GetRandomBigInteger(bitLength);
        Console.Write($"bit bitLength: {bitLength}; value : {randomBig} ");
        Console.WriteLine($"elapsed time: {GetElapsedTime(BrutForceKey, randomBig)}"); 
    }
}

Task1();
Task2();
Task3();