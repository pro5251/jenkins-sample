FROM jenkins/jenkins:lts-jdk21

USER root

# 安裝 Docker CLI、.NET 10 SDK、Node.js 所需相依套件
RUN apt-get update && apt-get install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    gnupg \
    lsb-release \
    sudo \
    && rm -rf /var/lib/apt/lists/*

# 安裝 Docker CLI 與 Compose Plugin
RUN curl -fsSL https://download.docker.com/linux/debian/gpg | gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg && \
    echo "deb [arch=$(dpkg --print-architecture) signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/debian $(lsb_release -cs) stable" | tee /etc/apt/sources.list.d/docker.list > /dev/null && \
    apt-get update && apt-get install -y docker-ce-cli docker-compose-plugin \
    && rm -rf /var/lib/apt/lists/*

# 安裝 .NET 10 SDK
RUN curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel 10.0 --install-dir /usr/share/dotnet && \
    ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet

# 安裝 Node.js 20 LTS
RUN curl -fsSL https://deb.nodesource.com/setup_20.x | bash - && \
    apt-get install -y nodejs \
    && rm -rf /var/lib/apt/lists/*

# 允許 jenkins 使用者透過 docker socket 執行 docker 指令
RUN usermod -aG docker jenkins 2>/dev/null || true && \
    echo "jenkins ALL=(ALL) NOPASSWD: ALL" >> /etc/sudoers

USER jenkins

# 安裝 Jenkins 插件
# configuration-as-code  : JCasC 設定即程式碼
# job-dsl                : Job DSL 自動建立 Job
# workflow-aggregator    : Pipeline 核心套件
# git                    : Git SCM 整合
# gitlab-plugin          : GitLab Webhook / MR 整合
# docker-workflow        : Pipeline 中使用 docker.build / docker.push
# credentials-binding    : Pipeline 中使用 withCredentials()
# ssh-credentials        : SSH Key 憑證管理
# build-timeout          : 建置逾時保護
# timestamper            : Console 輸出加時間戳
# ws-cleanup             : 建置後清理 Workspace
# ansicolor              : Console 彩色輸出
# pipeline-stage-view    : Pipeline 視覺化階段檢視
RUN jenkins-plugin-cli --plugins \
    configuration-as-code \
    job-dsl \
    workflow-aggregator \
    git \
    gitlab-plugin \
    docker-workflow \
    credentials-binding \
    ssh-credentials \
    build-timeout \
    timestamper \
    ws-cleanup \
    ansicolor \
    pipeline-stage-view

# 複製 JCasC 設定檔至映像中
COPY --chown=jenkins:jenkins jenkins.yaml /usr/share/jenkins/casc/jenkins.yaml

# 指定 JCasC 設定檔路徑（可被 Docker Compose volume mount 覆蓋）
ENV CASC_JENKINS_CONFIG=/usr/share/jenkins/casc/jenkins.yaml
