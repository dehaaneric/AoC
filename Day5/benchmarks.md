First attempt with dictionary

|    Method |     Mean |    Error |   StdDev |     Gen 0 | Allocated |
|---------- |---------:|---------:|---------:|----------:|----------:|
| Calculate | 25.85 ms | 0.232 ms | 0.206 ms | 4031.2500 |     12 MB |


Only strings for coordinate results

|      Method |     Mean |    Error |   StdDev |     Gen 0 | Allocated |
|------------ |---------:|---------:|---------:|----------:|----------:|
|   Calculate | 24.32 ms | 0.158 ms | 0.148 ms | 4031.2500 |     12 MB |
| CalculateV2 | 18.93 ms | 0.324 ms | 0.288 ms | 2250.0000 |      7 MB |


Introducing Coordinates struct

|      Method |        Mean |     Error |    StdDev |     Gen 0 | Allocated |
|------------ |------------:|----------:|----------:|----------:|----------:|
|   Calculate | 24,832.2 us | 473.59 us | 443.00 us | 4031.2500 |     12 MB |
| CalculateV2 | 17,937.7 us | 182.88 us | 171.07 us | 2000.0000 |      6 MB |
| CalculateV3 |    569.7 us |  10.79 us |  11.08 us | 1363.2813 |      4 MB |



|    Method |     Mean |     Error |    StdDev |     Gen 0 | Allocated |
|---------- |---------:|----------:|----------:|----------:|----------:|
| Calculate | 7.423 ms | 0.0555 ms | 0.0492 ms | 1132.8125 |      3 MB |