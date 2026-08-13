# FinAdvisor Web

Frontend starter for the FinAdvisor project using Next.js, TypeScript, Tailwind CSS, TanStack Query, Zod, and React Hook Form.

## Included

- App Router with route groups for auth and dashboard
- Login/register UI with validation
- Demo authentication persisted in localStorage
- Protected dashboard shell
- Sidebar/navigation and dashboard mock data
- Central API client with bearer-token support
- Feature-oriented frontend structure
- Empty Portfolio, Markets, Assets, and AI Advisor pages ready for implementation

## Run

```bash
npm install
cp .env.example .env.local
npm run dev
```

Then open http://localhost:3000.

The login form is prefilled for the demo; any valid email and password with at least six characters will work because authentication is mocked.

## Connect ASP.NET Identity

Open:

`src/features/auth/services/auth-service.ts`

Replace the mocked `login()` and `register()` implementations with calls to `apiRequest` from `src/lib/api.ts` once your backend endpoint contracts are finalized.

Set your backend API URL in `.env.local`:

```env
NEXT_PUBLIC_API_BASE_URL=https://localhost:7001/api
```
