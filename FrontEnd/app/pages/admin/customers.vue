<script setup lang="ts">
definePageMeta({
  layout: "admin",
});
</script>

<template>
  <div class="space-y-4">
    <div>
      <h1 class="text-3xl font-bold">Customers</h1>
      <p class="text-muted-foreground">Manage your customer base</p>
    </div>

    <div class="rounded-lg border bg-card">
      <div class="p-6">
        <h3 class="text-lg font-semibold mb-4">Customer List</h3>
        <div class="space-y-2">
          <div class="flex items-center justify-between p-4 border rounded">
            <div>
              <p class="font-medium">John Doe</p>
              <p class="text-sm text-muted-foreground">john@example.com</p>
            </div>
            <Button variant="outline" size="sm">View</Button>
          </div>

          <div class="flex items-center justify-between p-4 border rounded">
            <div>
              <p class="font-medium">Jane Smith</p>
              <p class="text-sm text-muted-foreground">jane@example.com</p>
            </div>
            <Button variant="outline" size="sm">View</Button>
          </div>

          <div class="flex items-center justify-between p-4 border rounded">
            <div>
              <p class="font-medium">Bob Johnson</p>
              <p class="text-sm text-muted-foreground">bob@example.com</p>
            </div>
            <Button variant="outline" size="sm">View</Button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
