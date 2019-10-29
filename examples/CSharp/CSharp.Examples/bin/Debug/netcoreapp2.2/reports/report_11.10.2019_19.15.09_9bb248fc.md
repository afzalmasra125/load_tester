# Scenario: `500`

- Duration: `00:02:00`
- RPS: `3`
- Concurrent Copies: `500`

| __step__                 | __details__                                                             |
|--------------------------|-------------------------------------------------------------------------|
| name                     | `GetAcceptances NA DLY`                                                 |
| request count            | all = `1916`, OK = `1399`, failed = `517`                               |
| response time            | RPS = `11`, min = `1186`, mean = `13398`, max = `50871`                 |
| response time percentile | 50% = `10767`, 75% = `11663`, 95% = `47391`, StdDev = `11053`           |
| data transfer            | min = `0.110 Kb`, mean = `0.110 Kb`, max = `0.110 Kb`, all = `0.160 MB` |
| name                     | `IsAcceptanceRequired NA DLY`                                           |
| request count            | all = `1280`, OK = `1010`, failed = `270`                               |
| response time            | RPS = `8`, min = `1189`, mean = `8763`, max = `13212`                   |
| response time percentile | 50% = `9567`, 75% = `10839`, 95% = `11895`, StdDev = `2796`             |
| data transfer            | min = `0.000 Kb`, mean = `0.110 Kb`, max = `0.110 Kb`, all = `0.110 MB` |
| name                     | `GetLatestDocuments NA DLY`                                             |
| request count            | all = `980`, OK = `891`, failed = `89`                                  |
| response time            | RPS = `7`, min = `70`, mean = `5707`, max = `43199`                     |
| response time percentile | 50% = `5611`, 75% = `8943`, 95% = `11439`, StdDev = `3752`              |
| data transfer            | min = `0.000 Kb`, mean = `0.090 Kb`, max = `0.090 Kb`, all = `0.080 MB` |
| name                     | `GetLatestDocumentServiceManager NA DLY`                                |
| request count            | all = `778`, OK = `682`, failed = `96`                                  |
| response time            | RPS = `5`, min = `491`, mean = `7660`, max = `12339`                    |
| response time percentile | 50% = `7527`, 75% = `10047`, 95% = `11647`, StdDev = `2723`             |
| data transfer            | min = `0.000 Kb`, mean = `0.100 Kb`, max = `0.110 Kb`, all = `0.080 MB` |
| name                     | `GetViewLatestDocument NA DLY`                                          |
| request count            | all = `593`, OK = `570`, failed = `23`                                  |
| response time            | RPS = `4`, min = `1164`, mean = `10545`, max = `19241`                  |
| response time percentile | 50% = `11711`, 75% = `13431`, 95% = `17503`, StdDev = `4723`            |
| data transfer            | min = `0.000 Kb`, mean = `1.220 Kb`, max = `1.440 Kb`, all = `0.800 MB` |
| name                     | `AcceptLatest`                                                          |
| request count            | all = `494`, OK = `428`, failed = `66`                                  |
| response time            | RPS = `3`, min = `1621`, mean = `6716`, max = `11968`                   |
| response time percentile | 50% = `7187`, 75% = `10375`, 95% = `11423`, StdDev = `3542`             |
| data transfer            | min = `0.000 Kb`, mean = `0.060 Kb`, max = `0.090 Kb`, all = `0.040 MB` |