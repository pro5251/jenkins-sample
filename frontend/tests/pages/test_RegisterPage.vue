import { describe, test, expect } from 'vitest';
import { mount } from '@vue/test-utils';
import RegisterPage from '../../src/pages/RegisterPage.vue';

describe('RegisterPage', () => {
  test('renders registration form', () => {
    const wrapper = mount(RegisterPage);
    expect(wrapper.find('form').exists()).toBe(true);
  });
});
