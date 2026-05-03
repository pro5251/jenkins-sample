# Unit Tests for English: Requirements Writing Quality Checklist

**Purpose**: Validate the quality, clarity, completeness, and readiness of requirements written in English.  
**Created**: 2026-05-03  
**Feature**: [spec.md](../spec.md)  
**Focus**: English requirements writing standards, terminology consistency, and measurable criteria.

## Checklist Items

### Requirement Completeness (Are all necessary requirements documented?)

- [ ] CHK001 - Are all user stories fully described with pre/post conditions? [Completeness]
- [ ] CHK002 - Are acceptance criteria defined for each user story? [Completeness]
- [ ] CHK003 - Are edge cases identified for critical user journeys? [Completeness, Gap]
- [ ] CHK004 - Are error/exception flows documented in requirements? [Completeness, Edge Case]
- [ ] CHK005 - Are non-functional requirements (performance, security) specified? [Completeness, Gap]
- [ ] CHK006 - Are dependencies on external systems documented? [Completeness, Dependency]
- [ ] CHK007 - Are assumptions and constraints explicitly stated? [Completeness, Assumptions]

### Requirement Clarity (Are requirements specific, unambiguous, and testable?)

- [ ] CHK008 - Is vague terminology (e.g., "fast", "intuitive") quantified with metrics? [Clarity, Ambiguity]
- [ ] CHK009 - Are all acronyms and domain terms defined on first use? [Clarity, Definitions]
- [ ] CHK010 - Are acceptance criteria measurable and objectively testable? [Clarity, Measurability]
- [ ] CHK011 - Do all requirements use consistent terminology throughout? [Clarity, Consistency]
- [ ] CHK012 - Are scope boundaries (in/out of scope) explicitly defined? [Clarity, Scope]

### Requirement Consistency (Do requirements align without conflicts?)

- [ ] CHK013 - Do requirements in different sections contradict each other? [Consistency, Conflict]
- [ ] CHK014 - Are priority assignments (P1, P2, P3) consistent across all stories? [Consistency]
- [ ] CHK015 - Do success criteria align with functional requirements? [Consistency, Traceability]
- [ ] CHK016 - Are acceptance scenarios consistent with requirement descriptions? [Consistency]

### Acceptance Criteria Quality (Are success criteria measurable and technology-agnostic?)

- [ ] CHK017 - Are all success criteria quantified with specific metrics? [Measurability, SC]
- [ ] CHK018 - Do success criteria avoid technology-specific language? [Measurability, Non-Functional]
- [ ] CHK019 - Can each success criterion be verified without implementation details? [Measurability, Testability]
- [ ] CHK020 - Are measurable outcomes defined for all user stories? [Measurability, Coverage]

### Scenario Coverage (Are all scenarios and edge cases addressed?)

- [ ] CHK021 - Are primary user journeys/scenarios fully described? [Coverage]
- [ ] CHK022 - Are alternate flows (if/else paths) identified? [Coverage, Gap]
- [ ] CHK023 - Are exception/error scenarios documented? [Coverage, Edge Case]
- [ ] CHK024 - Are concurrent/multi-user scenarios considered? [Coverage, Gap]
- [ ] CHK025 - Are recovery/fallback scenarios defined for critical flows? [Coverage, Exception Flow]

### Edge Case Coverage (Are boundary conditions and negative scenarios defined?)

- [ ] CHK026 - Are boundary value requirements specified (min/max, limits)? [Edge Case, Gap]
- [ ] CHK027 - Are negative scenarios (what system should NOT do) documented? [Edge Case]
- [ ] CHK028 - Are rate limiting/throttling requirements defined for APIs? [Edge Case, Non-Functional]
- [ ] CHK029 - Are data validation rules specified for all inputs? [Edge Case, Validation]

### Non-Functional Requirements (Performance, Security, Accessibility, etc.)

- [ ] CHK030 - Are performance requirements quantified with specific metrics/thresholds? [Non-Functional, Clarity]
- [ ] CHK031 - Are security requirements (auth, data protection) fully specified? [Non-Functional, Coverage]
- [ ] CHK032 - Are accessibility (a11y) requirements defined for UI components? [Non-Functional, Gap]
- [ ] CHK033 - Are compliance/regulatory requirements documented if applicable? [Non-Functional, Gap]

### Traceability & References (Can requirements be traced and verified?)

- [ ] CHK034 - Does each requirement have a unique ID for traceability? [Traceability]
- [ ] CHK035 - Do requirements reference relevant spec sections (e.g., [Spec §3.2])? [Traceability, References]
- [ ] CHK036 - Are dependencies between requirements explicitly mapped? [Traceability, Dependency]
- [ ] CHK037 - Can each requirement be linked to a test case? [Traceability, Testability]

### Ambiguities & Conflicts (What needs clarification?)

- [ ] CHK038 - Are ambiguous adjectives (e.g., "robust", "scalable") flagged for clarification? [Ambiguity]
- [ ] CHK039 - Are conflicting requirements identified and marked for resolution? [Conflict]
- [ ] CHK040 - Are assumptions requiring validation highlighted? [Assumptions, Gap]

## How to Use This Checklist

1. **For Authors**: Before finalizing English requirements, verify ALL items are checked.
2. **For Reviewers**: During spec review, verify each unchecked item is intentionally skipped with justification.
3. **For QA/Testing**: Use checked items to derive test cases; flagged gaps indicate missing test scenarios.
4. **For PR/CR**: Reference specific CHK IDs in review comments (e.g., "CHK012: terminology inconsistency noted").

## Notes

- This checklist is designed for requirements written in **English**.
- For Chinese/Traditional Chinese requirements, use a separate checklist (e.g., `unit-tests-chinese.md`).
- Items marked `[Gap]` indicate potential missing requirements; items marked `[Conflict]` indicate contradictions.
- Update this checklist as project evolves and new requirement types emerge.
