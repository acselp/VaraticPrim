<template>
  <admin-layout>
    <PageBreadcrumb :pageTitle="currentPageTitle" />

    <statistics-chart :series="series" />
  </admin-layout>
</template>

<script lang="ts" setup>

import PageBreadcrumb from '@/components/common/PageBreadcrumb.vue'
import AdminLayout from '@/components/layout/AdminLayout.vue'
import { ref } from 'vue'
import StatisticsChart from '@/components/ecommerce/StatisticsChart.vue'

function calculateDifferences(arr) {
  return arr.slice(1).map((num, index) => Math.abs(num - arr[index]));
}

const average = array => Math.floor(array.reduce((a, b) => a + b) / array.length);


const currentPageTitle = ref('Customer statistics')
const initialData = [412, 412, 412, 428, 435, 444, 448, 453, 458, 458, 458, 469, 469, 469, 474, 476, 479, 490, 491, 499, 504, 507, 515, 524, 524, 524, 524, 530, 533, 538, 543, 548, 548, 548, 576, 581, 581, 581, 581, 581, 609, 612, 612, 632, 632, 649, 649, 649, 657, 657, 657, 657, 682, 691, 706, 719, 724, 726, 728, 730, 730, 730.0, 763, 763, 763, 763, 791, 800, 809, 819, 828, 838, 838, 866, 866, 880, 890, 901, 912, 922, 934, 943, 943, 943, 960, 970, 987, 997, 1007, 1016, 1026, 1038, 1047, 1057, 1067, 1077, 1087, 1097, 1107, 1117, 1127, 1127, 1127, 1139, 1152, 1159, 1164, 1170, 1176, 1180, 1185, 1195, 1203, 1208]

const cleanedData = initialData.map((x, index) => {
  if (!x || x === 0 || Math.abs(x - initialData[index - 1]) > 110) {
    x = (initialData[index + 1] + initialData[index - 1]) / 2
  }

  return x
})

const difference = calculateDifferences(cleanedData)
const difAvg = average(difference)
debugger
let cleanedDiff = difference.map((x) => {
  if (x === 0) {
    return difAvg
  }

  return x
})

const series = ref([
  {
    name: 'Water meter',
    data: cleanedDiff
  },
])
</script>
