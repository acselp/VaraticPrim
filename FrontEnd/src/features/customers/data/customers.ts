import { faker } from '@faker-js/faker'
import { type Customer } from './schema'

// Set a fixed seed for consistent data generation
faker.seed(12345)

/**
 * Generate mock customer data (150 customers)
 * Frontend strategy - all data is client-side
 */
export const customersData: Customer[] = Array.from({ length: 150 }, () => {
  const firstName = faker.person.firstName()
  const lastName = faker.person.lastName()
  const totalOrders = faker.number.int({ min: 0, max: 50 })
  const avgOrderValue = faker.number.float({ min: 20, max: 500, fractionDigits: 2 })

  return {
    id: faker.string.uuid(),
    name: `${firstName} ${lastName}`,
    email: faker.internet.email({ firstName, lastName }).toLowerCase(),
    phone: faker.phone.number({ style: 'international' }),
    address: faker.location.streetAddress(),
    city: faker.location.city(),
    country: faker.location.country(),
    status: faker.helpers.arrayElement(['active', 'inactive', 'pending']),
    totalOrders,
    totalSpent: parseFloat((totalOrders * avgOrderValue).toFixed(2)),
    createdAt: faker.date.past({ years: 2 }),
    updatedAt: faker.date.recent({ days: 30 }),
  }
})
