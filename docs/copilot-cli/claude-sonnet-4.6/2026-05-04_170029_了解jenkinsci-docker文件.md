# 了解 jenkinsci/docker 文件

## 問題摘要
使用者要求閱讀並了解 https://github.com/jenkinsci/docker 的文件內容。

## 回答重點

### 基本資訊
- **官方映像**: `jenkins/jenkins`，可在 Docker Hub 取得
- **官方文件**: https://github.com/jenkinsci/docker

### 啟動方式
```bash
# 基本啟動
docker run -p 8080:8080 -p 50000:50000 --restart=on-failure jenkins/jenkins:lts-jdk21

# 含 Volume 的啟動（建議）
docker run -d -v jenkins_home:/var/jenkins_home -p 8080:8080 -p 50000:50000 --restart=on-failure jenkins/jenkins:lts-jdk21
```

### 重要連線埠
- **8080**: Jenkins Web UI
- **50000**: Agent TCP 連線（Inbound TCP）

### 資料持久化
- 所有資料存放於 `/var/jenkins_home`
- 建議使用 **Docker Named Volume**，避免 bind mount 造成的權限問題（容器內 jenkins user uid=1000）
- 初始密碼位置：`/var/jenkins_home/secrets/initialAdminPassword`

### 重要環境變數
| 變數 | 說明 |
|---|---|
| `JAVA_OPTS` | JVM 參數（全域） |
| `JENKINS_JAVA_OPTS` | JVM 參數（Jenkins 專用，優先使用此變數）|
| `JENKINS_OPTS` | Jenkins 啟動參數（prefix、HTTPS 等）|
| `JENKINS_SLAVE_AGENT_PORT` | Agent 連線埠（預設 50000）|
| `PLUGINS_FORCE_UPGRADE=true` | 強制升級手動安裝的插件 |
| `TRY_UPGRADE_IF_NO_MARKER=true` | 嘗試升級無標記的插件 |
| `PRE_CLEAR_INIT_GROOVY_D=true` | 清除 init.groovy.d 目錄 |

### 自訂 Dockerfile 範例
```dockerfile
FROM jenkins/jenkins:lts-jdk21
# 安裝系統套件（需要 root）
USER root
RUN apt-get update && apt-get install -y ruby make
USER jenkins

# 預安裝 Jenkins 插件
RUN jenkins-plugin-cli --plugins pipeline-model-definition github-branch-source:1.8

# 自訂 init script
COPY --chown=jenkins:jenkins custom.groovy /usr/share/jenkins/ref/init.groovy.d/custom.groovy

# 設定 executors 數量（建議 0 on built-in node）
COPY --chown=jenkins:jenkins executors.groovy /usr/share/jenkins/ref/init.groovy.d/executors.groovy
```

### 預安裝插件方式
```dockerfile
# 方式一：直接在 RUN 指定插件
RUN jenkins-plugin-cli --plugins pipeline-model-definition github-branch-source:1.8

# 方式二：透過插件清單檔案
COPY --chown=jenkins:jenkins plugins.txt /usr/share/jenkins/ref/plugins.txt
RUN jenkins-plugin-cli -f /usr/share/jenkins/ref/plugins.txt
```

### Docker Compose 範例
```yaml
services:
  jenkins:
    image: jenkins/jenkins:lts
    ports:
      - "8080:8080"
    volumes:
      - jenkins_home:/var/jenkins_home
    dns:
      - 1.1.1.1
      - 8.8.8.8
  ssh-agent:
    image: jenkins/ssh-agent
volumes:
  jenkins_home:
```

### 參考目錄 `/usr/share/jenkins/ref/`
- Jenkins 啟動時會將此目錄內容複製到 `JENKINS_HOME`
- 不會覆蓋已存在的檔案（除非檔名加上 `.override`）
- init scripts 放在 `init.groovy.d/` 子目錄

### Reverse Proxy 設定
```bash
docker run -e JENKINS_OPTS="--prefix=/jenkins" jenkins/jenkins:lts-jdk21
```

### HTTPS 設定範例
```dockerfile
FROM jenkins/jenkins:lts-jdk21
COPY --chown=jenkins:jenkins certificate.pfx /var/lib/jenkins/certificate.pfx
ENV JENKINS_OPTS="--httpPort=-1 --httpsPort=8083 --httpsKeyStore=/var/lib/jenkins/certificate.pfx --httpsKeyStorePassword=Password12"
EXPOSE 8083
```

### DNS 問題排解
若出現 "This Jenkins instance appears to be offline"：
```bash
docker run --dns 1.1.1.1 --dns 8.8.8.8 jenkins/jenkins:lts-jdk21
```

## 執行的操作
- 讀取 `jenkinsci/docker` GitHub repository 的 README.md 全文（392 行，約 18KB）
- 整理並摘要文件內容

## 相關連結
- GitHub: https://github.com/jenkinsci/docker
- Docker Hub: https://hub.docker.com/r/jenkins/jenkins/
- 官方文件: https://jenkins.io/
- Plugin Installation Manager: https://github.com/jenkinsci/plugin-installation-manager-tool/
