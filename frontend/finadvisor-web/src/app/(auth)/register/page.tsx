import Link from "next/link";
import { RegisterForm } from "@/components/auth/RegisterForm";

export default function RegisterPage() {
  return (
    <div>
      <h2 className="mb-1 text-xl font-bold">Create your account</h2>
      <p className="mb-6 text-sm text-[var(--muted)]">Set up your FinAdvisor workspace.</p>
      <RegisterForm />
      <p className="mt-6 text-center text-sm text-[var(--muted)]">Already registered? <Link className="font-semibold text-[var(--primary)]" href="/login">Sign in</Link></p>
    </div>
  );
}
