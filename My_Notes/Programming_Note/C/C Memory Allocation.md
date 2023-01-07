# Memory Allocation

#c #memory 

[reference](https://openhome.cc/Gossip/CGossip/MallocFree.html)

[[CS50_l4(2020)]]

到目前為止，變數建立後會配置記憶體空間，這類資源是配置在記憶體的堆疊區（Stack），生命週期侷限於函式執行期間，也就是函式執行過後，配置的空間就會自動清除。

若要將函式執行結果傳回，不能直接傳回這類被自動配置空間的位址，因為函式執行過後，該空間就會釋出，函式呼叫者後續若透過位址取用這些資源，會發生不可預期的結果，例如，不能直接將區域建立的變數位址或陣列位址傳回。

然而程式運行後，資源之間的互用關係錯綜複雜，有些資源「無法預期」被使用的生命週期，因為無法預期，也就有賴於開發者自行管理記憶體資源，也就是開發者得自行在需要的時候配置記憶體，這些記憶體會被配置在堆積區（Heap），不會自動清除，開發者得在不使用資源時自行釋放記憶體。

要自行配置記憶體，C 可以使用 `malloc`，它定義在 stdlib.h，舉例來說，可以在程式中以動態方式配置一個 `int` 型態大小的記憶體，例如：

```
int *p = malloc(sizeof(int));
```

在這段程式中，`malloc` 會配置一個 `int` 需要的空間，並傳回該空間的位址，可以使用指標 `p` 來儲存位址，就 C11 規範來說，`malloc` 只配置空間但不初始空間的值，若要在配置完成後預設為型態的零值，可以使用 `calloc`：

```
int *p = calloc(1, sizeof(int));
```

若要釋放記憶體，可以使用 `free` 函式，以下使用一個簡單的程式來示範動態配置的使用：

```
#include <stdio.h>
#include <stdlib.h>

int main(int argc, char *argv[]) {
    int *p = malloc(100); 

    printf("空間位址：%p\n", p);
    printf("儲存的值：%d\n", *p);

    *p = 200; 

    printf("空間位址：%p\n", p);
    printf("儲存的值：%d\n", *p);

    free(p);

    return 0; 
}
```

執行結果：

```
空間位址：006F0D60
儲存的值：7274688
空間位址：006F0D60
儲存的值：200
```

動態配置的空間，在程式結束前不會自動歸還，必須使用 `free` 釋放空間，若大量動態配置而沒有適當使用 `free` 的話，由於空間一直沒有歸還，最後將導致整個記憶體空間用盡。

如果想配置連續個指定型態的空間，可以如下：

```
int *p = malloc(sizeof(int) * 1000);
```

這段程式碼動態配置了 1000 個 `int` 大小的空間，並傳回空間的第一個位址，配置後的空間資料是未知的，，可以使用 `calloc` 來宣告空間配置，每個 `int` 空間會被始為 0，例如：

```
int *p = calloc(1000, sizeof(int));
```

配置的空間長度必須自行儲存下來，因為沒有任何方式，可以從 `p` 得知到底配置的長度是多少，配置得來的空間，在不使用時同樣是使用 `free` 釋放，方法如下：

```
free(p);
```

下面這個程式是個動態配置空間，並模擬為陣列來操作的簡單示範：

```
#include <stdio.h>
#include <stdlib.h>

int main(void) {
    int size = 0;

    printf("輸入長度：");
    scanf("%d", &size);

    int *arr = malloc(size * sizeof(int));

    printf("指定元素：\n");
    for(int i = 0; i < size; i++) {
        printf("arr[%d] = ", i);
        scanf("%d" , arr + i);
    }

    printf("顯示元素：\n");
    for(int i = 0; i < size; i++) {
        printf("arr[%d] = %d\n", i, *(arr+i));
    }

    free(arr);

    return 0;
}
```

執行結果：

```
輸入長度：3
指定元素：
arr[0] = 10
arr[1] = 20
arr[2] = 30
顯示元素：
arr[0] = 10
arr[1] = 20
arr[2] = 30
```

若要動態配置連續空間，並當成二維陣列來操作，就記得二維（或多維）陣列，就是以陣列的陣列來實作，二維陣列就是多段一維陣列，如果你的二維陣列有兩段一維陣列，那就是如下：

```
int **arr = calloc(2, sizeof(int*));
```

現在 `arr[0]`、`arr[1]` 可以分別儲存動態配置 `int*` 空間的位址，若每段要模擬的一維陣列的長度是 3，可以如下動態配置，並將模擬的一維陣列每個元素初始設為 0 ：

```
for(int i = 0; i < 2; i++) {
    arr[i] = calloc(3, sizeof(int));
}
```

來看一下簡單的範例：

```
#include <stdio.h>
#include <stdlib.h>

int main(void) {
    int **arr = calloc(2, sizeof(int*));
    for(int i = 0; i < 2; i++) {
        arr[i] = calloc(3, sizeof(int));
    }

    for(int i = 0; i < 2; i++) {
        for(int j = 0; j < 3; j++) {
            printf("%d ", arr[i][j]);
        }
        putchar('\n');
    }

    for(int i = 0; i < 2; i++) {
        free(arr[i]);
    }
    free(arr); 

    return 0;
}
```

記得最後要釋放配置的空間時，也要如以上範例逐一釋放，執行結果如下：

```
0 0 0
0 0 0
```

既然可以動態配置，那每段模擬的一維陣列長度當然可以不一樣囉！

```
#include <stdio.h>
#include <stdlib.h>

int main(void) {
    int **arr = calloc(2, sizeof(int*));
    arr[0] = calloc(3, sizeof(int));
    arr[1] = calloc(5, sizeof(int));

    for(int j = 0; j < 3; j++) {
        printf("%d ", arr[0][j]);
    }
    putchar('\n');

    for(int j = 0; j < 5; j++) {
        printf("%d ", arr[1][j]);
    }
    putchar('\n');    

    for(int i = 0; i < 2; i++) {
        free(arr[i]);
    }
    free(arr); 

    return 0;
}
```

執行結果：

```
0 0 0
0 0 0 0 0
```

如果要改變已配置的記憶體大小，可以使用 `realloc`，例如：

```
#include <stdio.h>
#include <stdlib.h>

int main(void) {
    int size = 0;

    printf("陣列長度：");
    scanf("%d", &size);
    int *arr1 = calloc(size, sizeof(int));

    printf("指定元素：\n");
    for(int i = 0; i < size; i++) {
        printf("arr1[%d] = ", i);
        scanf("%d" , arr1 + i);
    }

    printf("顯示元素：\n");
    for(int i = 0; i < size; i++) {
        printf("arr1[%d] = %d\n", i, *(arr1 + i));
    }

    int *arr2 = realloc(arr1, sizeof(int) * size * 2);
    printf("顯示元素：\n");
    for(int i = 0; i < size * 2; i++) {
        printf("arr2[%d] = %d\n", i, *(arr2 + i));
    }

    printf("arr1 位址：%p\n", arr1);
    printf("arr2 位址：%p\n", arr2);

    free(arr2);

    return 0;
}
```

執行結果：

```
陣列長度：3
指定元素：
arr1[0] = 10
arr1[1] = 20
arr1[2] = 30
顯示元素：
arr1[0] = 10
arr1[1] = 20
arr1[2] = 30
顯示元素：
arr2[0] = 10
arr2[1] = 20
arr2[2] = 30
arr2[3] = 0
arr2[4] = 1409286485
arr2[5] = 51325
arr1 位址：00650D60
arr2 位址：00650D60
```

要注意的是，上例中，重新配置後的位址並不保證相同，`realloc` 會複製資料來改變記憶體的大小，若原位址有足夠的空間，使用原位址調整記憶體的大小，若空間不足，會重新尋找足夠的空間來進行配置，在這個情況下，`realloc` 前舊位址的空間會被釋放掉，也就是說，必須使用 `realloc` 傳回的新位址，而不該使用舊位址，若 `realloc` 失敗會傳回空指標（null），因此最好對位址進行檢查。

對於動態配置的記憶體，若有個指標是唯一指向資源位址，可以使用 `restrict` 修飾，例如：

```
int *restrict p = calloc(1, sizeof(int));
```

被 `restrict` 修飾的指標，表示由開發者指示編譯器，這個資源只由該指標存取，如此一來，編譯器就有機會進行最佳化，唯一性是由開發者掌握，編譯器不會檢查被 `restrict` 修飾的指標，指向的資源是否被其他指標指向。

`restrict` 對程式碼閱讀上，也具有提醒開發者的作用，表示不該有其他指標儲存相同資源的位址，在函式簽署上，也可提示多個資源的位址必須是獨立的，例如 `strcpy` 的簽署，聲明了 `dest` 與 `src` 必須是不同的：

```
char *strcpy( char *restrict dest, const char *restrict src );
```