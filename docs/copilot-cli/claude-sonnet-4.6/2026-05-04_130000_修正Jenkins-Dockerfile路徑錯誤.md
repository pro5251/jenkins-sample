# Hotfix: Jenkins Dockerfile Path Error

## Issue Description
When building the `docker-jenkins` image, the build failed at the step where it attempts to add the Docker apt repository.

**Error Message:**
`tee /etc/lib/apt/lists/docker.list: No such file or directory`

**Root Cause:**
The path `/etc/lib/apt/lists/docker.list` was incorrect. In Debian-based systems, custom apt source lists should be placed in `/etc/apt/sources.list.d/`.

## Resolution
Updated `docker/jenkins/Dockerfile` to use the correct path: `/etc/apt/sources.list.d/docker.list`.

## Impact
This fix allows the Jenkins image to correctly install the Docker CLI and Docker Compose plugin, enabling the CI/CD pipeline to interact with the host's Docker daemon.

## Verification
- Modified `docker/jenkins/Dockerfile`.
- Recommended action: Re-run `docker-compose -f docker/ci-cd-docker-compose.yml up -d --build`.
