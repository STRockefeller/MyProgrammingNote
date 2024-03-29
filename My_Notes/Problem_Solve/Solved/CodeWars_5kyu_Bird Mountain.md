# CodeWars:Bird Mountain:20210128:C\#

tags: #problem_solve #c_sharp #codewars/5kyu

[Reference](https://www.codewars.com/kata/5c09ccc9b48e912946000157)

## Question

## Kata Task

A bird flying high above a mountain range is able to estimate the height of the highest peak.

Can you?

## Example

## The birds-eye view

```
^^^^^^
 ^^^^^^^^
  ^^^^^^^
  ^^^^^
  ^^^^^^^^^^^
  ^^^^^^
  ^^^^
```

## The bird-brain calculations

```
111111
 1^^^^111
  1^^^^11
  1^^^1
  1^^^^111111
  1^^^11
  1111
```

```
111111
 12222111
  12^^211
  12^21
  12^^2111111
  122211
  1111
```

```
111111
 12222111
  1233211
  12321
  12332111111
  122211
  1111
```

```
Height = 3
```

## My Solution

難得看到比較有趣的題目來記錄一下解題過程。

作法:

標記外圍-->刪除外圍，高度加一-->LOOP

標記外圍的作法:

1.第一行和最後一行都確定是外圍

2.上下左右的位置有至少一個`' '`

大放送，順便把過程print出來

```C#
using System;
using System.Linq;
public class Dinglemouse
{
    public static int PeakHeight(char[][] mountain)
    {
        char outsideChar = ' ';
        char newLabel = '1';
        while(!mountain.All(ca=>ca.All(c=>c != '^')))
        {
            printMountain(mountain);
            mountain = outsideDetection(mountain,outsideChar,newLabel);
            outsideChar = newLabel;
            newLabel = (char)(newLabel+1);
        }
        printMountain(mountain);
        return newLabel-'0'-1;
    }
    private static char[][] outsideDetection(char[][] mountain,char outsideChar,char newLabel,char target='^')
    {
        for(int i = 0; i < mountain.Length; i++)
        {
            if(i == 0 || i == mountain.Length-1)
            {    for(int j = 0; j < mountain[0].Length; j++)
                    mountain[i][j] = mountain[i][j] == target ? newLabel : mountain[i][j];
                continue;
            }
            for(int j = 0; j < mountain[0].Length; j++)
            {
                if(mountain[i][j] == target)
                {
                    if(j == 0 || j == mountain[0].Length-1){mountain[i][j] = newLabel;}
                    if(i != 0) {mountain[i][j] = mountain[i-1][j] == outsideChar?  newLabel : mountain[i][j];}
                    if(j != 0) {mountain[i][j] = mountain[i][j-1] == outsideChar?  newLabel : mountain[i][j];}
                    if(i != mountain.Length-1) {mountain[i][j] = mountain[i+1][j] == outsideChar?  newLabel : mountain[i][j];}
                    if(j != mountain[0].Length-1) {mountain[i][j] = mountain[i][j+1] == outsideChar?  newLabel : mountain[i][j];}
                }
            }
        }
        return mountain;
    }
    private static void printMountain(char[][] mountain)
    {
        Console.WriteLine("---Print Start---");
        foreach (char[] item in mountain)
            Console.WriteLine(String.Join("",item));
        Console.WriteLine("---Print Finish---");
    }
}
```

範例題目運作結果

```
---Print Start---
^^^^^^
 ^^^^^^^^
  ^^^^^^^
  ^^^^^
  ^^^^^^^^^^^
  ^^^^^^
  ^^^^
---Print Finish---
---Print Start---
111111
 1^^^^111
  1^^^^11
  1^^^1
  1^^^^111111
  1^^^11
  1111
---Print Finish---
---Print Start---
111111
 12222111
  12^^211
  12^21
  12^^2111111
  122211
  1111
---Print Finish---
---Print Start---
111111
 12222111
  1233211
  12321
  12332111111
  122211
  1111
---Print Finish---

```

通關。

雖然用了很多LOOP感覺效率極差，不過目前沒想到其他解法，所以就算了。

## Better Solutions

### Solution 1

```C#
using System;
using System.Linq;
public class Dinglemouse
{
  public static int PeakHeight(char[][] mntn)
  {
    var m = mntn.Select((arr,r) => arr.Select((x,c) => x == ' ' ? 0 : 1).ToArray()).ToArray();
    for (int e = 2; e <= (m.Length/2+1); e++)
    {
      for (int r = 1; r < m.Length-1; r++)
      {
        for (int c = 1; c < m[r].Length-1; c++)
        {
          if (m[r][c] >= 1)
          {  
            m[r][c] = new [] { m[r-1][c],m[r+1][c], m[r][c-1], m[r][c+1] }.Min() + 1;
          }
        }
      }
    }
    return m.SelectMany(x => x).Max();
  }
}
```

### Solution 2

```C#
using System.Linq;
public class Dinglemouse
{
  public static int PeakHeight(char[][] m, int h = 0) =>
    !m.SelectMany(x => x).Any(r => r=='^') ? h :
      PeakHeight(m.Select((a,r) => a.Select((x,c) => 
        (r<1 || c<1 || c==a.Length-1 || r==m.Length-1 || new[]{x, m[r-1][c], m[r+1][c], a[c-1], a[c+1]}.Any(z => z==' ') ? 
        ' ' : x)).ToArray()).ToArray(), h+1);
}
```

看到one-line solution都先給尊重。但說實話這個解法真的不好懂。

為了遞迴多設定一個參數h並給予預設值0，代表高度

`SelectMany`做深度為2的查詢(`char[][]`->`char[]`->`char`)，如果沒有`'^'`代表目前的高度即為最高值，則直接回傳。

若還有則執行

```C#
PeakHeight(m.Select((a,r) => a.Select((x,c) =>
        (r<1 || c<1 || c==a.Length-1 || r==m.Length-1 || new[]{x, m[r-1][c], m[r+1][c], a[c-1], a[c+1]}.Any(z => z==' ') ? 
        ' ' : x)).ToArray()).ToArray(), h+1);
```

`Select`委派傳入兩個參數算是比較少見的用法，第一個參數就是平常會拿到的值，第二個則會是index (int) ，[參考](https://stackoverflow.com/questions/2471588/how-to-get-index-using-linq)

以這個解答的寫法來說，變數分別會是

|             | a      | r          | x    | c          |
| ----------- | ------ | ---------- | ---- | ---------- |
| Type        | char[] | int        | char | int        |
| Description |        | index of a |      | index of a |

接著就比較簡單了

```C#
r<1 || c<1 || c==a.Length-1 || r==m.Length-1 || new[]{x, m[r-1][c], m[r+1][c], a[c-1], a[c+1]}.Any(z => z==' ') ? ' ' : x
```

根據條件判斷是否要清空或保持原樣回傳，至於條件，顯然就是判斷是否在外圍。

最後將這個已經更動過的array以及h+1作為參數進行遞迴。
