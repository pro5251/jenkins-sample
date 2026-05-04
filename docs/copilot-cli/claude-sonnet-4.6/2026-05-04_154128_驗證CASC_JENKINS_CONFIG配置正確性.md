# 驗證 CASC_JENKINS_CONFIG 配置是否正確

## 問題摘要
確認 `docker-compose.yml` 中 `CASC_JENKINS_CONFIG` 的配置是否正確

## 回答重點

### 問題發現
`CASC_JENKINS_CONFIG` 在兩處都被定義：
1. `docker/jenkins/Dockerfile` 第 44 行：`ENV CASC_JENKINS_CONFIG=/var/jenkins_home/casc/jenkins.yaml`
2. `docker/ci-cd-docker-compose.yml` 環境變數（剛新增的）

值完全相同，屬於**重複定義**。docker-compose 的值會覆蓋 Dockerfile 的 ENV，功能上沒問題但造成維護混淆。

### 修正方式
移除 `docker-compose.yml` 中重複的 `CASC_JENKINS_CONFIG`，由 Dockerfile 統一管理。

## 執行操作
從 `docker/ci-cd-docker-compose.yml` 的 environment 區塊移除重複的 `CASC_JENKINS_CONFIG`

## 產出檔案
- 修改：`docker/ci-cd-docker-compose.yml`（移除重複環境變數）
