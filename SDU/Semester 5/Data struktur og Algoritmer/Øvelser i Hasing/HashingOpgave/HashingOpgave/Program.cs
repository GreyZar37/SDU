
using System.Collections;


/* ====Opgave 1====
int[] tabel =
[
    22, 0, 0, 0,0,5,16,0,0,27,0
];

int[] values =
[
    1,12,23,22, 4128451
];


foreach (int value in values)
{
    Console.WriteLine(HashFunction(value, tabel.Length));
}

Console.WriteLine(HashFunction(27, tabel.Length));


int HashFunction(int x, int tabelSize)
{
    return x % tabelSize;
}*/

/*
// ====Opgave 2====

//=====Insert DEMOCRAT=====
string?[] tableDemocrat = new string?[16];


int LinearInsert(string?[] t, char letter)
{
    int m = t.Length;
    int k = KFromLetter(letter);
    int h = HashK(k, m);

    for (int step = 0; step < m; step++)
    {
        int pos = (h + step) % m;
        if (t[pos] == null) { t[pos] = letter.ToString(); return pos; }
        if (t[pos] == letter.ToString()) return pos; // already there
    }
    throw new InvalidOperationException("Table is full");
}


foreach (var ch in "DEMOCRAT")
{
    int pos = LinearInsert(tableDemocrat, ch);
    Console.WriteLine($"{ch} -> placed at {pos}");
}

for (int i = 0; i < tableDemocrat.Length; i++)
    Console.WriteLine($"{i}: {tableDemocrat[i] ?? "."}");




//====Insert REPUBLICAN====
string?[] tableRepublican = new string?[16];

int QuadraticInsert(string?[] t, char letter)
{
    int m = t.Length;
    int k = KFromLetter(letter);
    int h = HashK(k, m);

    for (int step = 0; step < m; step++)
    {
        int pos = (h + step * step) % m ;
        if (t[pos] == null) { t[pos] = letter.ToString(); return pos; }
        if (t[pos] == letter.ToString()) return pos; // already there
    }
    throw new InvalidOperationException("Table is full");
}


int KFromLetter(char ch) => char.ToUpper(ch) - 'A' + 1;
int HashK(int k, int m) => (11 * k) % m;

foreach (var ch in "REPUBLICAN")
{
    int pos = QuadraticInsert(tableRepublican, ch);
    Console.WriteLine($"{ch} -> placed at {pos}");
}

for (int i = 0; i < tableRepublican.Length; i++)
    Console.WriteLine($"{i}: {tableRepublican[i] ?? "."}");

*/

// ====Opgave 3====


// a.




/* ===Single Choice====

int N = 32749, trials = 200;

var rng = new Random();
var bins = new int[N];

for (int t = 0; t < trials; t++)
{
    Array.Clear(bins, 0, N);
    for (int i = 0; i < N; i++)
        bins[rng.Next(N)]++;

    int maxLoad = 0;
    for (int i = 0; i < N; i++)
        if (bins[i] > maxLoad) maxLoad = bins[i];

    Console.WriteLine($"Trial {t+1}: max = {maxLoad}");
}

*/

//====Multiple Choice====

int N = 10007, trials = 200;
var rng = new Random();
var bins = new int[N];

for (int t = 0; t < trials; t++)
{
    Array.Clear(bins, 0, N);

    for (int i = 0; i < N; i++)
    {
        int a = rng.Next(N);
        int b = rng.Next(N);
        if (bins[a] <= bins[b]) bins[a]++; else bins[b]++;  
    }

    int maxLoad = 0;
    for (int i = 0; i < N; i++)
        if (bins[i] > maxLoad) maxLoad = bins[i];

    Console.WriteLine($"Trial {t+1}: max = {maxLoad}");
}
