"use client";

import { Bell } from "lucide-react";
import { useEffect, useState } from "react";
import type { AuthUser } from "@/features/auth/types/auth";

export function Navbar() {
  const [user, setUser] = useState<AuthUser | null>(null);
  useEffect(() => {
    const raw = localStorage.getItem("finadvisor_user");
    if (raw) setUser(JSON.parse(raw));
  }, []);

  return (
    <header className="flex h-16 items-center justify-between border-b border-[var(--border)] bg-white px-7">
      <div><p className="text-sm text-[var(--muted)]">Financial workspace</p></div>
      <div className="flex items-center gap-4">
        <button className="grid size-10 place-items-center rounded-xl border border-[var(--border)]"><Bell size={18} /></button>
        <div className="text-right"><p className="text-sm font-semibold">{user?.name ?? "FinAdvisor User"}</p><p className="text-xs text-[var(--muted)]">{user?.email ?? ""}</p></div>
        <div className="grid size-10 place-items-center rounded-full bg-indigo-100 font-bold text-[var(--primary)]">{user?.name?.[0]?.toUpperCase() ?? "F"}</div>
      </div>
    </header>
  );
}
