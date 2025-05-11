import {
  GridIcon,
  PieChartIcon, PlugInIcon,
  TableIcon,
  UserCircleIcon
} from '@/icons'
import type { SidebarGroup } from '@/components/layout/AppSidebar/types.ts'

export const clientMenuGroups: SidebarGroup[] = [
  {
    title: "Menu",
    items: [
      {
        icon: UserCircleIcon,
        name: "Customer",
        subItems: [
          {
            name: "Manage customers",
            path: "/customers",
          },
          {
            name: "Manage addresses",
            path: "/addresses",
          },
          {
            name: "Statistics",
            path: "/statistics",
          },
        ],
      },
      {
        icon: GridIcon,
        name: "Billing operations",
        subItems: [
          {
            name: "Reports",
            path: "/reports"
          },
          {
            name: "Billings",
            path: "/billings"
          }
        ]
      },
      {
        name: "Counters",
        icon: TableIcon,
        subItems: [
          {
            name: "Manage counters",
            path: "/counters"
          },
          {
            name: "Counter installation",
            path: "/installations"
          },
        ],
      },
    ],
  },
  {
    title: "Others",
    items: [
      {
        icon: PieChartIcon,
        name: "Service and Support",
        path: "/support"
      },
      {
        icon: PlugInIcon,
        name: "System settings",
        subItems: [
          { name: "Signin", path: "/signin", pro: false },
          { name: "Signup", path: "/signup", pro: false },
        ],
      },
    ],
  },
];
