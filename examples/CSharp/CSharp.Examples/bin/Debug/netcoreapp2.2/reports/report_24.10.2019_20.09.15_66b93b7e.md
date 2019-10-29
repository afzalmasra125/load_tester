# Scenario: `500`

- Duration: `00:02:00`
- RPS: `0`
- Concurrent Copies: `500`

| __step__                 | __details__                                                             |
|--------------------------|-------------------------------------------------------------------------|
| name                     | `IsAcceptanceRequired NA DLY`                                           |
| request count            | all = `851`, OK = `724`, failed = `127`                                 |
| response time            | RPS = `6`, min = `246`, mean = `11108`, max = `105077`                  |
| response time percentile | 50% = `6979`, 75% = `14535`, 95% = `33503`, StdDev = `11839`            |
| data transfer            | min = `0.000 Kb`, mean = `0.050 Kb`, max = `0.110 Kb`, all = `0.080 MB` |
| name                     | `GetLatestDocuments NA DLY`                                             |
| request count            | all = `659`, OK = `659`, failed = `0`                                   |
| response time            | RPS = `5`, min = `40`, mean = `6260`, max = `37049`                     |
| response time percentile | 50% = `5251`, 75% = `8863`, 95% = `16767`, StdDev = `5088`              |
| data transfer            | min = `0.000 Kb`, mean = `0.040 Kb`, max = `0.090 Kb`, all = `0.060 MB` |
| name                     | `GetLatestDocumentServiceManager NA DLY`                                |
| request count            | all = `599`, OK = `599`, failed = `0`                                   |
| response time            | RPS = `4`, min = `92`, mean = `7834`, max = `44804`                     |
| response time percentile | 50% = `6023`, 75% = `9191`, 95% = `25679`, StdDev = `7641`              |
| data transfer            | min = `0.000 Kb`, mean = `0.050 Kb`, max = `0.110 Kb`, all = `0.070 MB` |
| name                     | `GetViewLatestDocument NA DLY`                                          |
| request count            | all = `599`, OK = `0`, failed = `599`                                   |
| response time            | RPS = `0`, min = `0`, mean = `0`, max = `0`                             |
| response time percentile | 50% = `0`, 75% = `0`, 95% = `0`, StdDev = `0`                           |
| data transfer            | min = - , mean = - , max = - , all = -                                  |
| name                     | `AcceptLatest`                                                          |
| request count            | all = `0`, OK = `0`, failed = `0`                                       |
| response time            | RPS = `0`, min = `0`, mean = `0`, max = `0`                             |
| response time percentile | 50% = `0`, 75% = `0`, 95% = `0`, StdDev = `0`                           |
| data transfer            | min = - , mean = - , max = - , all = -                                  |