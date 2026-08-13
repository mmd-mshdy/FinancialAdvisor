import Link from "next/link";
import { LoginForm } from "@/components/auth/LoginForm";

export default function LoginPage() {
  return (
    <div>
      <h2 className="mb-1 text-xl font-bold">Welcome back</h2>
      <p className="mb-6 text-sm text-[var(--muted)]">Sign in to continue to your dashboard.</p>
      <LoginForm />
      <p className="mt-6 text-center text-sm text-[var(--muted)]">New to FinAdvisor? <Link className="font-semibold text-[var(--primary)]" href="/register">Create an account</Link></p>
    </div>
  );
}
