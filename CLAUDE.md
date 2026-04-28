# Camp Clot Not — Claude Code Briefing

## What This Is
A Blazor Server (.NET 8) web app for Camp Clot Not (CCN), a camp for kids with bleeding disorders run by HBDA (Alabama chapter). The 2026 theme is Super Mario Party. The platform is being built to run camp scoring/competition for June 20-25, 2026, with a longer-term goal of replacing the chapter's Yapp subscription (~$1,600/year) for all chapter events.

**Primary spec:** `REQUIREMENTS.md`  
**Schema redesign spec:** `docs/superpowers/specs/2026-04-28-schema-redesign.md`

---

## Current State (as of 2026-04-28)

**Active branch:** `feature/1-foundation`  
**Milestone:** v0.1.0 — Foundation (~May 4 target)

**Done:**
- Blazor Server scaffold (entities, repositories, services, SignalR hub, MudBlazor pages)
- Build errors fixed (missing usings, AuthorizeView context, _Imports.razor)
- Local PostgreSQL running (`hbda_dev`), EF Core migration applied (10 tables)
- REQUIREMENTS.md updated with post-pitch decisions
- Schema redesign designed and spec'd — **not yet implemented in code**

**Up next:**
1. Implement the redesigned schema (replace scaffold entities with spec schema)
2. New EF Core migration
3. Auth decision: BCrypt/cookie (current) vs Auth0 — security review pending
4. Seed data: EventType (CCN), Capabilities, ActivityTypeCategories, CurrencyType, AwardType, Authorities, UserRoles
5. Get app running locally (F5 in VS) — needs a seeded admin user to log in

---

## Architecture — Critical Points

- **Railway.app hosting** — PORT env var is injected, never hardcode. postgres:// URI converted in Program.cs. HTTPS terminated externally — no ForceHttpsRedirection in prod.
- **Blazor Server + SignalR** — projector display (/display route) receives real-time updates via SignalR hub (`/camphub`). Block hit animation MUST play on projector via SignalR broadcast triggered from admin tablet — plan hub message types before building.
- **No Flask middleware in v1** — service → repository → EF Core → PostgreSQL. Flask/Minimal API extracted in v2 when a second client exists.
- **Append-only transactions** — coins/stars never deleted, only voided. Totals always computed from non-voided transactions, never stored.
- **Pre-scripted board** — block hit and mini-game spinner are NOT random. Pre-scripted by admin before camp.

---

## Schema (redesigned — spec in docs/)

Key tables replacing the scaffold:

| Concept | Tables |
|---|---|
| Event scoping | `EventType`, `Event` (replaces `CampSeason`) |
| Feature flags | `Capability`, `EventCapability` (per-instance, seeded from type) |
| Activities | `ActivityTypeCategory`, `ActivityType`, `Activity` |
| Competition | `CurrencyType`, `Group`, `Transaction`, `BoardSpace`, `GroupBoardPos`, `ScriptedBlockHit`, `ScriptedMiniGame` |
| Awards | `AwardType`, `CamperAward` |
| Auth/RBAC | `UserRole`, `Authority`, `UserRoleAuthorityLink`, `UserAuthorityLink`, `User` |

**Column convention:** `Name` (short label) + `Description` (human-readable) + `SystemName` (stable code identifier, what C# enums map to) on all reference/catalog tables.

**C# enums:** One set per domain, values map to `SystemName` strings. No base/impl split.

**Auth evaluation:** Load role authorities + user additions at login → cache in session claims. Zero DB cost on checks.

---

## Open Decisions

- [ ] Group count for CCN 2026 (4-6 — waiting on cabin groupings)
- [ ] Board space count (waiting on activity list finalization with Katelyn/Vicki)
- [ ] Auth approach: BCrypt/cookie vs Auth0 (security review needed)

---

## Branching

```
main            — 2021 code + REQUIREMENTS.md + mockup. Protected.
archive/2021    — frozen 2021 Python/React capstone
dev             — integration branch
feature/1-foundation  — active development (YOU ARE HERE)
```

---

## Key Files

| File | Purpose |
|---|---|
| `REQUIREMENTS.md` | Full functional spec, animation spec, infrastructure, decisions |
| `docs/superpowers/specs/2026-04-28-schema-redesign.md` | Schema redesign rationale and full table definitions |
| `mockup/ccn-mockup-v2.jsx` | React prototype — primary visual reference for UI |
| `mockup/assets/ccn-logo-2026.png` | Camp logo |
| `CampClotNot/` | Blazor Server project |
| `CampClotNot/appsettings.Development.json` | Local DB connection string (gitignored) |

---

## Local Dev Setup

- **DB:** PostgreSQL local, database `hbda_dev`
- **Connection string:** `CampClotNot/appsettings.Development.json` (gitignored — update password locally)
- **Run migrations:** `dotnet ef database update` in PMC or terminal
- **Start app:** F5 in Visual Studio Community (open `CampClotNot/CampClotNot.csproj`)
- **Mockup preview:** `cd mockup/preview && npm run dev` → http://localhost:5173
