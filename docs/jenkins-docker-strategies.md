# Docker-in-Jenkins: DooD vs. DinD

When running Jenkins inside a Docker container and needing it to perform Docker operations (like `docker build` or `docker-compose`), there are two primary strategies.

## 1. Docker-out-of-Docker (DooD) / Docker Socket Mounting
This approach involves mounting the host's Docker socket (`/var/run/docker.sock`) into the Jenkins container.

### Pros:
- **Performance:** Jenkins uses the host's Docker engine directly, sharing the host's image cache.
- **Simplicity:** No nested Docker engines; easy to set up.
- **Resources:** Lower overhead than running a nested Docker daemon.

### Cons:
- **Security:** The Jenkins container has root-level access to the host's Docker engine. A compromised Jenkins container could potentially control or damage the host.
- **Permissions:** Requires matching UID/GID or permissive socket permissions to allow the `jenkins` user to access the socket.

## 2. Docker-in-Docker (DinD)
This approach involves running a complete Docker daemon inside the Jenkins container (or as a sidecar).

### Pros:
- **Isolation:** The CI environment has its own private Docker daemon and image cache, isolated from the host.
- **Cleanliness:** Builds don't "pollute" the host's Docker image list.

### Cons:
- **Complexity:** Requires running the container in `--privileged` mode (significant security risk).
- **Performance:** Filesystem overhead (especially with COW drivers) can make builds slower.
- **Storage:** Uses significantly more disk space as images are duplicated within the container.

## Chosen Strategy: DooD (Docker Socket Mounting)
For this local development setup, we have chosen **DooD** because:
1. It is the most practical for a single developer's machine.
2. It allows you to see the containers and images created by Jenkins directly on your host machine using `docker ps`.
3. It avoids the complexities and performance penalties of nested filesystems.

**Security Note:** In a production multi-tenant environment, DinD or specialized CI runners (like GitLab Runners with isolated executors) are preferred for better security isolation.
