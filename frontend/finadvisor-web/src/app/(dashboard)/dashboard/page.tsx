import { ArrowUpRight, BrainCircuit, ShieldCheck, WalletCards } from "lucide-react";
import { Card } from "@/components/ui/Card";

const assets = [
  { symbol: "BTC", name: "Bitcoin", value: "$11,182.50", change: "+2.4%", allocation: "45%" },
  { symbol: "ETH", name: "Ethereum", value: "$7,455.00", change: "+1.7%", allocation: "30%" },
  { symbol: "SOL", name: "Solana", value: "$3,727.50", change: "-0.8%", allocation: "15%" },
];

export default function DashboardPage() {
  return (
    <div className="mx-auto max-w-7xl">
      <div className="mb-7"><p className="text-sm font-medium text-[var(--primary)]">Overview</p><h1 className="mt-1 text-3xl font-bold">Good evening</h1><p className="mt-2 text-[var(--muted)]">Here is what is happening across your financial world.</p></div>

      <div className="grid gap-4 md:grid-cols-3">
        <Card><div className="flex items-center justify-between"><span className="grid size-11 place-items-center rounded-xl bg-indigo-50 text-[var(--primary)]"><WalletCards size={20}/></span><span className="text-sm font-semibold text-[var(--success)]">+3.28%</span></div><p className="mt-5 text-sm text-[var(--muted)]">Portfolio value</p><p className="mt-1 text-3xl font-bold">$24,850</p></Card>
        <Card><div className="flex items-center justify-between"><span className="grid size-11 place-items-center rounded-xl bg-emerald-50 text-emerald-700"><ShieldCheck size={20}/></span><span className="text-sm text-[var(--muted)]">Moderate</span></div><p className="mt-5 text-sm text-[var(--muted)]">Risk score</p><p className="mt-1 text-3xl font-bold">62 / 100</p></Card>
        <Card><div className="flex items-center justify-between"><span className="grid size-11 place-items-center rounded-xl bg-violet-50 text-violet-700"><BrainCircuit size={20}/></span><span className="text-sm text-[var(--muted)]">JEPA-ready</span></div><p className="mt-5 text-sm text-[var(--muted)]">AI insights</p><p className="mt-1 text-3xl font-bold">4 new</p></Card>
      </div>

      <div className="mt-4 grid gap-4 lg:grid-cols-[1.4fr_1fr]">
        <Card>
          <div className="flex items-center justify-between"><div><h2 className="text-lg font-bold">Portfolio allocation</h2><p className="text-sm text-[var(--muted)]">Mock data until the Assets/Portfolio API is connected.</p></div><ArrowUpRight size={18}/></div>
          <div className="mt-5 space-y-4">{assets.map((asset) => <div key={asset.symbol} className="grid grid-cols-[1fr_auto_auto] items-center gap-5 rounded-xl bg-slate-50 p-4"><div><p className="font-bold">{asset.symbol}</p><p className="text-xs text-[var(--muted)]">{asset.name} · {asset.allocation}</p></div><p className="font-semibold">{asset.value}</p><p className={`text-sm font-semibold ${asset.change.startsWith("+") ? "text-emerald-600" : "text-red-500"}`}>{asset.change}</p></div>)}</div>
        </Card>
        <Card>
          <p className="text-xs font-bold uppercase tracking-[0.18em] text-[var(--primary)]">AI Financial Insight</p>
          <h2 className="mt-4 text-xl font-bold">Portfolio concentration is increasing.</h2>
          <p className="mt-3 leading-7 text-[var(--muted)]">Bitcoin currently represents 45% of your mock portfolio. As the Advisory module comes online, this card can surface JEPA-based state representations, risk changes, and recommended actions.</p>
          <button className="mt-6 font-semibold text-[var(--primary)]">View analysis →</button>
        </Card>
      </div>
    </div>
  );
}
