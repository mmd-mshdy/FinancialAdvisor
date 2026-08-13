export default function AuthLayout({ children }: { children: React.ReactNode }) {
  return (
    <main className="grid min-h-screen place-items-center bg-[var(--background)] px-4">
      <section className="w-full max-w-md rounded-3xl border border-[var(--border)] bg-white p-8 shadow-sm">
        <div className="mb-8">
          <p className="text-sm font-semibold uppercase tracking-[0.2em] text-[var(--primary)]">FinAdvisor</p>
          <h1 className="mt-2 text-3xl font-bold">Your financial intelligence workspace</h1>
          <p className="mt-2 text-sm leading-6 text-[var(--muted)]">Secure access to portfolios, markets, assets, and AI-driven financial insights.</p>
        </div>
        {children}
      </section>
    </main>
  );
}
