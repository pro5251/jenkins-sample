# 安裝 Jenkins Expert Skill

## 問題摘要
使用者要求安裝 jenkins-expert skills。

## 執行過程

### 問題診斷
第一次嘗試使用 `skill` 工具直接呼叫，發現 `jenkins-expert` 不在 `<available_skills>` 清單中。

### 根本原因
Copilot CLI 的 Skill 有兩種位置：
1. **Plugin Skill**（`location: plugin`）— 來自已安裝的 Plugin
2. **Custom Skill**（`location: custom`）— 來自 `~/.copilot/settings.json` 的 `skillDirectories` 設定

上次安裝時將 Skill 放在 `~/.copilot/skills/`，但正確路徑應為 `skillDirectories` 設定的目錄：
```json
"skillDirectories": ["/mnt/d/.github/skills"]
```

### 正確的 Skill 格式
```
/mnt/d/.github/skills/
└── jenkins-expert/
    └── SKILL.md     ← 含 frontmatter（name + description）
```

`SKILL.md` 結構：
```markdown
---
name: jenkins-expert
description: ...
---
# Skill 內容
```

## 執行的操作
1. 查看 `~/.copilot/settings.json` 找到正確的 `skillDirectories`
2. 參考 `note-organizer` 的目錄結構確認格式
3. 建立 `/mnt/d/.github/skills/jenkins-expert/SKILL.md`
4. 更新 `docs/copilot-skills/install-jenkins-expert.sh`，改為自動讀取 `skillDirectories` 設定

## 安裝結果
- **安裝位置**：`/mnt/d/.github/skills/jenkins-expert/SKILL.md` ✅
- **下次重啟 CLI 後**即可在 `<available_skills>` 中看到 `jenkins-expert`

## 產出的檔案
- `/mnt/d/.github/skills/jenkins-expert/SKILL.md` — 已安裝的 Skill
- `docs/copilot-skills/install-jenkins-expert.sh` — 更新安裝腳本（自動偵測 skillDirectories）
