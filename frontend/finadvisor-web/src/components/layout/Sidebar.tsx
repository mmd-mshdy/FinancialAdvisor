"use client";

import Link from "next/link";
import { usePathname, useRouter } from "next/navigation";
import { BarChart3, Bot, Coins, LayoutDashboard, LogOut, PieChart } from "lucide-react";
import { authService } from "@/features/auth/services/auth-service";

const links = [
  { href: "/dashboard", label: "Dashboard", icon: LayoutDashboard },
  { href: "/portfolio", label: "Portfolio", icon: PieChart },
  { href: "/markets", label: "Markets", icon: BarChart3 },
  { href: "/assets", label: "Assets", icon: Coins },
  { href: "/advisor", label: "AI Advisor", icon: Bot },
];

export function Sidebar() {
  const pathname = usePathname();
  const router = useRouter();

  const logout = () => {
    authService.logout();
    router.replace("/login");
  };

  return (
    <aside className="flex min-h-screen w-64 flex-col border-r border-[var(--border)] bg-white p-4">
      <div className="px-3 py-4 text-xl font-black tracking-tight">FinAdvisor</div>
      <nav className="mt-5 flex-1 space-y-1">
        {links.map(({ href, label, icon: Icon }) => {
          const active = pathname === href;
          return (
            <Link key={href} href={href} className={`flex items-center gap-3 rounded-xl px-3 py-3 text-sm font-medium transition ${active ? "bg-indigo-50 text-[var(--primary)]" : "text-[var(--muted)] hover:bg-slate-50 hover:text-[var(--foreground)]"}`}>
              <Icon size={18} />{label}
            </Link>
          );
        })}
      </nav>
      <button onClick={logout} className="flex items-center gap-3 rounded-xl px-3 py-3 text-sm font-medium text-[var(--muted)] transition hover:bg-red-50 hover:text-red-600"><LogOut size={18} />Log out</button>
    </aside>
  );
}
