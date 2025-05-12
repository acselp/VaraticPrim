import {
  GridIcon,
  PieChartIcon,
  UserCircleIcon
} from '@/icons'
import type { SidebarGroup } from '@/components/layout/AppSidebar/types.ts'

export const clientMenuGroups: SidebarGroup[] = [
  {
    title: "Menu",
    items: [
      {
        icon: UserCircleIcon,
        name: "Account",
        subItems: [
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
            name: "Pay service",
            path: "/payments"
          },
          {
            name: "Invoices",
            path: "/invoices"
          }
        ]
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
    ],
  },
];
