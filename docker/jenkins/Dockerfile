FROM jenkins/jenkins:lts

USER root

# Install dependencies for Docker, .NET, and Node.js
RUN apt-get update && apt-get install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    gnupg \
    lsb-release \
    sudo

# Install Docker CLI
RUN curl -fsSL https://download.docker.com/linux/debian/gpg | gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg && \
    echo "deb [arch=$(dpkg --print-architecture) signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/debian $(lsb_release -cs) stable" | tee /etc/apt/sources.list.d/docker.list > /dev/null && \
    apt-get update && apt-get install -y docker-ce-cli docker-compose-plugin

# Install .NET 10 SDK (Based on 2026 release cycle)
RUN curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel 10.0 --install-dir /usr/share/dotnet && \
    ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet

# Install Node.js (LTS)
RUN curl -fsSL https://deb.nodesource.com/setup_20.x | bash - && \
    apt-get install -y nodejs

# Allow jenkins user to use sudo without password (for docker socket access if needed)
RUN echo "jenkins ALL=(ALL) NOPASSWD: ALL" >> /etc/sudoers

# Clean up
RUN apt-get clean && rm -rf /var/lib/apt/lists/*

# Install JCasC and Pipeline plugins
RUN jenkins-plugin-cli --plugins \
    configuration-as-code \
    job-dsl \
    workflow-aggregator \
    git \
    pipeline-stage-view

USER jenkins

# Copy JCasC config into image
COPY --chown=jenkins:jenkins jenkins.yaml /usr/share/jenkins/casc/jenkins.yaml

# Tell JCasC where to find the config file
ENV CASC_JENKINS_CONFIG=/usr/share/jenkins/casc/jenkins.yaml
