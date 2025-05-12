<template>
  <admin-layout>
    <PageBreadcrumb :pageTitle="currentPageTitle" />
    <div class="col-span-full">
      <label for="cover-photo" class="block text-sm/6 font-medium text-gray-900">Water meter photo</label>
      <div class="mt-2 flex justify-center rounded-lg border border-dashed border-gray-900/25 px-6 py-10">
        <div v-if="!imgSrc" class="text-center">
          <div class="mt-4 flex text-sm/6 text-gray-600">
            <label for="file-upload" class="relative cursor-pointer rounded-md bg-white font-semibold text-indigo-600 focus-within:ring-2 focus-within:ring-indigo-600 focus-within:ring-offset-2 focus-within:outline-hidden hover:text-indigo-500">
              <span>Upload a file</span>
              <input id="file-upload" @input="onUpload" accept=".png,.jpeg,.gif,.jpg" name="file-upload" type="file" class="sr-only" />
            </label>
            <p class="pl-1">or drag and drop</p>
          </div>
          <p class="text-xs/5 text-gray-600">PNG, JPG, GIF up to 10MB</p>
        </div>

        <div v-else-if="imgSrc" class="h-200px">
          <img style="max-height: 18rem;
    max-width: 18rem;
    height: 100%;
    width: 100%;
    object-fit: cover;" class="h-auto max-h-fit max-w-lg rounded-lg hover:shadow-lg" :src="imgSrc" alt="description" />
          <button @click="onRemoveFile" class="px-4 py-2 mt-2 bg-red-800 w-full text-white font-semibold rounded-md hover:bg-red-900 focus:outline-none focus:ring-red-600 focus:ring-offset-2">
            Remove
          </button>
        </div>

      </div>
    </div>

    <div v-if="loadingData" role="status" class="ml-auto mr-auto mt-4 mb-2 w-fit">
      <svg aria-hidden="true" class="w-8 h-8 text-gray-200 animate-spin dark:text-gray-600 fill-blue-600" viewBox="0 0 100 101" fill="none" xmlns="http://www.w3.org/2000/svg">
        <path d="M100 50.5908C100 78.2051 77.6142 100.591 50 100.591C22.3858 100.591 0 78.2051 0 50.5908C0 22.9766 22.3858 0.59082 50 0.59082C77.6142 0.59082 100 22.9766 100 50.5908ZM9.08144 50.5908C9.08144 73.1895 27.4013 91.5094 50 91.5094C72.5987 91.5094 90.9186 73.1895 90.9186 50.5908C90.9186 27.9921 72.5987 9.67226 50 9.67226C27.4013 9.67226 9.08144 27.9921 9.08144 50.5908Z" fill="currentColor"/>
        <path d="M93.9676 39.0409C96.393 38.4038 97.8624 35.9116 97.0079 33.5539C95.2932 28.8227 92.871 24.3692 89.8167 20.348C85.8452 15.1192 80.8826 10.7238 75.2124 7.41289C69.5422 4.10194 63.2754 1.94025 56.7698 1.05124C51.7666 0.367541 46.6976 0.446843 41.7345 1.27873C39.2613 1.69328 37.813 4.19778 38.4501 6.62326C39.0873 9.04874 41.5694 10.4717 44.0505 10.1071C47.8511 9.54855 51.7191 9.52689 55.5402 10.0491C60.8642 10.7766 65.9928 12.5457 70.6331 15.2552C75.2735 17.9648 79.3347 21.5619 82.5849 25.841C84.9175 28.9121 86.7997 32.2913 88.1811 35.8758C89.083 38.2158 91.5421 39.6781 93.9676 39.0409Z" fill="currentFill"/>
      </svg>
      <span class="sr-only">Loading...</span>
    </div>

    <template v-if="!loadingData && imgSrc">
      <div class="mt-4 p-5 mb-6 border border-gray-200 rounded-2xl dark:border-gray-800 lg:p-6">
        <div class="flex flex-col gap-6 lg:flex-row lg:items-start lg:justify-between">
        <div>
          <h4 class="text-lg font-semibold text-gray-800 dark:text-white/90 lg:mb-6">
            Payment information
          </h4>

          <div class="grid grid-cols-1 gap-4 lg:grid-cols-3 lg:gap-7 2xl:gap-x-32">
            <div>
              <p class="mb-2 text-xs leading-normal text-gray-500 dark:text-gray-400">Previous value</p>
              <p class="text-sm font-medium text-gray-800 dark:text-white/90">{{ previousValue }}</p>
            </div>

            <div>
              <p class="mb-2 text-xs leading-normal text-gray-500 dark:text-gray-400">Current value</p>
              <p class="text-sm font-medium text-gray-800 dark:text-white/90">{{ currentValue }}</p>
            </div>

            <div>
              <p class="mb-2 text-xs leading-normal text-gray-500 dark:text-gray-400">
                Tarif
              </p>
              <p class="text-sm font-medium text-gray-800 dark:text-white/90">
                {{tarif}} lei / m3
              </p>
            </div>

            <div>
              <p class="mb-2 text-xs leading-normal text-gray-500 dark:text-gray-400">Total</p>
              <p class="text-sm font-medium text-gray-800 dark:text-white/90">{{ fullPrice }} lei</p>
            </div>

            <div>
              <Button variant="outline" @click="isPayModalActive = true">
                Pay
              </Button>
            </div>

            <Modal v-if="isPayModalActive" @close="isPayModalActive = false">
              <template #body>
                <div
                  class="no-scrollbar relative w-full max-w-[1500px] overflow-y-auto rounded-3xl bg-white p-4 dark:bg-gray-900 lg:p-11"
                >
                  <section class="bg-white py-8 antialiased dark:bg-gray-900 md:py-16">
                    <div class="mx-auto max-w-screen-xl px-4 2xl:px-0">
                      <div class="mx-auto max-w-5xl">
                        <h2 class="text-xl font-semibold text-gray-900 dark:text-white sm:text-2xl">Payment</h2>

                        <div class="mt-6 sm:mt-8 lg:flex lg:items-start lg:gap-12">
                          <form action="#" class="w-full rounded-lg border border-gray-200 bg-white p-4 shadow-sm dark:border-gray-700 dark:bg-gray-800 sm:p-6 lg:max-w-xl lg:p-8">
                            <div class="mb-6 grid grid-cols-2 gap-4">
                              <div class="col-span-2 sm:col-span-1">
                                <label for="full_name" class="mb-2 block text-sm font-medium text-gray-900 dark:text-white"> Full name (as displayed on card)* </label>
                                <input type="text" id="full_name" class="block w-full rounded-lg border border-gray-300 bg-gray-50 p-2.5 text-sm text-gray-900 focus:border-primary-500 focus:ring-primary-500 dark:border-gray-600 dark:bg-gray-700 dark:text-white dark:placeholder:text-gray-400 dark:focus:border-primary-500 dark:focus:ring-primary-500" placeholder="Bonnie Green" required />
                              </div>

                              <div class="col-span-2 sm:col-span-1">
                                <label for="card-number-input" class="mb-2 block text-sm font-medium text-gray-900 dark:text-white"> Card number* </label>
                                <input type="text" id="card-number-input" class="block w-full rounded-lg border border-gray-300 bg-gray-50 p-2.5 pe-10 text-sm text-gray-900 focus:border-primary-500 focus:ring-primary-500  dark:border-gray-600 dark:bg-gray-700 dark:text-white dark:placeholder:text-gray-400 dark:focus:border-primary-500 dark:focus:ring-primary-500" placeholder="xxxx-xxxx-xxxx-xxxx" pattern="^4[0-9]{12}(?:[0-9]{3})?$" required />
                              </div>

                              <div>
                                <label for="card-expiration-input" class="mb-2 block text-sm font-medium text-gray-900 dark:text-white">Card expiration* </label>
                                <div class="relative">
                                  <div class="pointer-events-none absolute inset-y-0 start-0 flex items-center ps-3.5">
                                    <svg class="h-4 w-4 text-gray-500 dark:text-gray-400" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" viewBox="0 0 24 24">
                                      <path
                                        fill-rule="evenodd"
                                        d="M5 5a1 1 0 0 0 1-1 1 1 0 1 1 2 0 1 1 0 0 0 1 1h1a1 1 0 0 0 1-1 1 1 0 1 1 2 0 1 1 0 0 0 1 1h1a1 1 0 0 0 1-1 1 1 0 1 1 2 0 1 1 0 0 0 1 1 2 2 0 0 1 2 2v1a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1V7a2 2 0 0 1 2-2ZM3 19v-7a1 1 0 0 1 1-1h16a1 1 0 0 1 1 1v7a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2Zm6.01-6a1 1 0 1 0-2 0 1 1 0 0 0 2 0Zm2 0a1 1 0 1 1 2 0 1 1 0 0 1-2 0Zm6 0a1 1 0 1 0-2 0 1 1 0 0 0 2 0Zm-10 4a1 1 0 1 1 2 0 1 1 0 0 1-2 0Zm6 0a1 1 0 1 0-2 0 1 1 0 0 0 2 0Zm2 0a1 1 0 1 1 2 0 1 1 0 0 1-2 0Z"
                                        clip-rule="evenodd"
                                      />
                                    </svg>
                                  </div>
                                  <input datepicker datepicker-format="mm/yy" id="card-expiration-input" type="text" class="block w-full rounded-lg border border-gray-300 bg-gray-50 p-2.5 ps-9 text-sm text-gray-900 focus:border-blue-500 focus:ring-blue-500 dark:border-gray-600 dark:bg-gray-700 dark:text-white dark:placeholder:text-gray-400 dark:focus:border-blue-500 dark:focus:ring-blue-500" placeholder="12/23" required />
                                </div>
                              </div>
                              <div>
                                <label for="cvv-input" class="mb-2 flex items-center gap-1 text-sm font-medium text-gray-900 dark:text-white">
                                  CVV*
                                  <button data-tooltip-target="cvv-desc" data-tooltip-trigger="hover" class="text-gray-400 hover:text-gray-900 dark:text-gray-500 dark:hover:text-white">
                                    <svg class="h-4 w-4" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 24 24">
                                      <path fill-rule="evenodd" d="M2 12C2 6.477 6.477 2 12 2s10 4.477 10 10-4.477 10-10 10S2 17.523 2 12Zm9.408-5.5a1 1 0 1 0 0 2h.01a1 1 0 1 0 0-2h-.01ZM10 10a1 1 0 1 0 0 2h1v3h-1a1 1 0 1 0 0 2h4a1 1 0 1 0 0-2h-1v-4a1 1 0 0 0-1-1h-2Z" clip-rule="evenodd" />
                                    </svg>
                                  </button>
                                  <div id="cvv-desc" role="tooltip" class="tooltip invisible absolute z-10 inline-block rounded-lg bg-gray-900 px-3 py-2 text-sm font-medium text-white opacity-0 shadow-sm transition-opacity duration-300 dark:bg-gray-700">
                                    The last 3 digits on back of card
                                    <div class="tooltip-arrow" data-popper-arrow></div>
                                  </div>
                                </label>
                                <input type="number" id="cvv-input" aria-describedby="helper-text-explanation" class="block w-full rounded-lg border border-gray-300 bg-gray-50 p-2.5 text-sm text-gray-900 focus:border-primary-500 focus:ring-primary-500 dark:border-gray-600 dark:bg-gray-700 dark:text-white dark:placeholder:text-gray-400 dark:focus:border-primary-500 dark:focus:ring-primary-500" placeholder="•••" required />
                              </div>
                            </div>

                            <Button @click="onPayNow">Pay now</Button>
                          </form>

                          <div class="mt-6 grow sm:mt-8 lg:mt-0">
                            <div class="space-y-4 rounded-lg border border-gray-100 bg-gray-50 p-6 dark:border-gray-700 dark:bg-gray-800">
                              <div class="space-y-2">
                                <dl class="flex items-center justify-between gap-4">
                                  <dt class="text-base font-normal text-gray-500 dark:text-gray-400">Original price</dt>
                                  <dd class="text-base font-medium text-gray-900 dark:text-white">{{ fullPrice }} lei</dd>
                                </dl>

                                <dl class="flex items-center justify-between gap-4">
                                  <dt class="text-base font-normal text-gray-500 dark:text-gray-400">Tarif</dt>
                                  <dd class="text-base font-medium text-gray-900 dark:text-white">{{ tarif }} lei / m3</dd>
                                </dl>
                              </div>

                              <dl class="flex items-center justify-between gap-4 border-t border-gray-200 pt-2 dark:border-gray-700">
                                <dt class="text-base font-bold text-gray-900 dark:text-white">Total</dt>
                                <dd class="text-base font-bold text-gray-900 dark:text-white">{{ fullPrice }} lei</dd>
                              </dl>
                            </div>

                            <div class="mt-6 flex items-center justify-center gap-8">
                              <img class="h-8 w-auto dark:hidden" src="https://flowbite.s3.amazonaws.com/blocks/e-commerce/brand-logos/paypal.svg" alt="" />
                              <img class="hidden h-8 w-auto dark:flex" src="https://flowbite.s3.amazonaws.com/blocks/e-commerce/brand-logos/paypal-dark.svg" alt="" />
                              <img class="h-8 w-auto dark:hidden" src="https://flowbite.s3.amazonaws.com/blocks/e-commerce/brand-logos/visa.svg" alt="" />
                              <img class="hidden h-8 w-auto dark:flex" src="https://flowbite.s3.amazonaws.com/blocks/e-commerce/brand-logos/visa-dark.svg" alt="" />
                              <img class="h-8 w-auto dark:hidden" src="https://flowbite.s3.amazonaws.com/blocks/e-commerce/brand-logos/mastercard.svg" alt="" />
                              <img class="hidden h-8 w-auto dark:flex" src="https://flowbite.s3.amazonaws.com/blocks/e-commerce/brand-logos/mastercard-dark.svg" alt="" />
                            </div>
                          </div>
                        </div>

                        <p class="mt-6 text-center text-gray-500 dark:text-gray-400 sm:mt-8 lg:text-left">
                          Payment processed by <a href="#" title="" class="font-medium text-primary-700 underline hover:no-underline dark:text-primary-500">Paddle</a> for <a href="#" title="" class="font-medium text-primary-700 underline hover:no-underline dark:text-primary-500">Flowbite LLC</a>
                          - United States Of America
                        </p>
                      </div>
                    </div>
                  </section>

                </div>
              </template>
            </Modal>
          </div>
        </div>
        </div>
      </div>
    </template>


    <Alert
      :active="isSuccessToastActive"
      variant="success"
      title="Payment successful"
      message="Payment has been successfully done."
    />
  </admin-layout>
</template>

<script lang="ts" setup>

import PageBreadcrumb from '@/components/common/PageBreadcrumb.vue'
import AdminLayout from '@/components/layout/AdminLayout.vue'
import { computed, ref } from 'vue'
import Button from '@/components/ui/Button.vue'
import Modal from '@/components/profile/Modal.vue'
import Alert from '@/components/ui/Alert.vue'

const currentPageTitle = ref("Pay services")
const file = ref<File>()
const imgSrc = ref()

const loadingData = ref(false)
const isPayModalActive = ref(false)
const isSuccessToastActive = ref(false)

const onUpload = (event: InputEvent) => {
  loadingData.value = true
  const file = event.target.files[0];
  if (file) {
    file.value = file
    const reader = new FileReader();
    reader.onload = (e) => {
      imgSrc.value = e.target.result;
    };
    reader.readAsDataURL(file);
  }

  setTimeout(() => {
    loadingData.value = false
  }, 2000)
}

const onRemoveFile = () => {
  file.value = undefined;
  imgSrc.value = null;
}

const onPayNow = () => {
  isPayModalActive.value = false

  setTimeout(() => {
    isSuccessToastActive.value = true
    setTimeout(() => {
      isSuccessToastActive.value = false
    }, 3000)
  }, 200)

}

const previousValue = ref(244)
const currentValue = ref(252)
const tarif = ref(16)
const fullPrice = computed(() => {
  return (currentValue.value - previousValue.value) * tarif.value
})

</script>
