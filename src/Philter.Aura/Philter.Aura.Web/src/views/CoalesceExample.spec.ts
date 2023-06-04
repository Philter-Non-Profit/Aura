import { mount, flushPromises, mockEndpoint } from "@/test-utils";

import { VTextField } from "vuetify/components";
import CoalesceExample from "./CoalesceExample.vue";

describe("CoalesceExample.vue", () => {
  it("loads user id 1", async () => {
    // Arrange
    mockEndpoint("/ApplicationUser/get", () => ({
      wasSuccessful: true,
      object: { applicationUserId: 1, name: "Steve" },
    }));

    // Act
    const wrapper = mount(CoalesceExample);
    await flushPromises();

    // Assert
    expect(wrapper.text()).toMatch("Editing User ID: 1");
    expect(document.title).toMatch("Steve");
    expect(wrapper.findComponent(VTextField).vm.modelValue).toBe("Steve");
  });
});
