<!-- SPECKIT START -->
For additional context about technologies to be used, project structure,
shell commands, and other important information, read the plan at:
specs/001-shopping-website-cicd/plan.md
<!-- SPECKIT END -->

## 問答記錄規則

每次與 AI 進行問答後，必須將問題與答案進行總結，並記錄在以下路徑：

**記錄路徑**: `docs/opencode/{model_name}/yyyy-MM-dd_HHmmss_問題簡易摘要.md`

**規則說明**:
1. **模型名稱**: 根據當前使用的 AI 模型名稱 (例如: hy3-preview-free)
2. **時間格式**: 使用系統當前時間，格式為 yyyy-MM-dd_HHmmss (例如: 2026-05-03_090700)
3. **檔案命名**: 使用問題的簡易摘要作為檔名 (例如: 建立專案憲法與Specify.md)
4. **記錄時機**: 每次完成一個完整的問答循環後立即生成
5. **內容格式**:
   - 使用繁體中文撰寫
   - 包含問題摘要、回答重點、執行的操作、產出的檔案
   - 使用 Markdown 格式

**示例**:
- 路徑: `docs/opencode/hy3-preview-free/2026-05-03_090700_建立專案憲法.md`
- 內容: 記錄用戶請求建立憲法、執行的操作、產出的檔案清單
