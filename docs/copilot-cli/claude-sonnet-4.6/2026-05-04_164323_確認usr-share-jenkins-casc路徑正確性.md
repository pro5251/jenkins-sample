# 確認 /usr/share/jenkins/casc/ 路徑是否正確

## 問題摘要
確認 JCasC 設定檔放在 `/usr/share/jenkins/casc/jenkins.yaml` 是否正確

## 回答重點

### 結論：不正確，`ref/` 不能省略

| 路徑 | 機制 | 是否有效 |
|------|------|---------|
| `/usr/share/jenkins/ref/casc/` | Jenkins Docker seed 機制 | ✅ 啟動時自動複製到 jenkins_home |
| `/usr/share/jenkins/casc/` | 無對應機制 | ❌ 不會被讀取 |
| `/var/jenkins_home/casc/` | JCasC 實際讀取位置 | ✅ 由 CASC_JENKINS_CONFIG 指定 |

### 官方文件依據
官方 Jenkins Docker README 範例：
```dockerfile
COPY --chown=jenkins:jenkins executors.groovy /usr/share/jenkins/ref/init.groovy.d/executors.groovy
```
`ref/` 是固定前綴，不可省略。

### 目前 Dockerfile 配置正確
```dockerfile
COPY --chown=jenkins:jenkins jenkins.yaml /usr/share/jenkins/ref/casc/jenkins.yaml
```

## 產出檔案
無（純確認，未修改任何檔案）
