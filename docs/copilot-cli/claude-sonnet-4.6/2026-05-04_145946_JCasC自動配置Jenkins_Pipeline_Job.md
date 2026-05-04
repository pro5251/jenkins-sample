# 透過 JCasC 自動配置 Jenkins Pipeline Job

## 問題摘要

用戶詢問是否可以不透過 Jenkins UI 手動建立 Job，而是透過配置檔 mount 進容器自動完成。

## 解決方案：Jenkins Configuration as Code (JCasC)

透過 YAML 檔定義 Jenkins 系統設定與 Job，容器啟動時自動載入。

## 執行操作

### 1. 修改 `docker/jenkins/Dockerfile`
新增安裝 JCasC 相關 plugins：
- `configuration-as-code`
- `job-dsl`
- `workflow-aggregator`
- `git`
- `pipeline-stage-view`

設定環境變數 `CASC_JENKINS_CONFIG` 指向設定檔路徑。

### 2. 新增 `docker/jenkins/jenkins.yaml`
定義：
- Jenkins 系統訊息
- admin 帳號（預設密碼 admin）
- Pipeline Job（jenkins-sample），指向 GitHub repo，每 5 分鐘輪詢 SCM

### 3. 修改 `docker/ci-cd-docker-compose.yml`
- mount `jenkins.yaml` 進容器：`./jenkins/jenkins.yaml:/var/jenkins_home/casc/jenkins.yaml:ro`
- 設定 `JAVA_OPTS=-Djenkins.install.runSetupWizard=false` 跳過 Setup Wizard

## 啟動指令

```bash
cd docker
docker compose -f ci-cd-docker-compose.yml up -d --build jenkins
```

## 產出檔案

- `docker/jenkins/Dockerfile`（修改）
- `docker/jenkins/jenkins.yaml`（新增）
- `docker/ci-cd-docker-compose.yml`（修改）
