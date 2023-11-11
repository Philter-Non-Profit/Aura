import { mount, flushPromises, mockEndpoint } from "@/test-utils";

import { VTextField } from "vuetify/components";
import CoalesceExample from "./CoalesceExample.vue";

describe("CoalesceExample.vue", () => {
  it("loads user id 8F9B1EF2-E5D1-467D-9E8D-1C0336BCE684", async () => {
    // Arrange
    mockEndpoint("/AuraUser/get", () => ({
      wasSuccessful: true,
      object: { auraUserId: "8F9B1EF2-E5D1-467D-9E8D-1C0336BCE684", name: "Squidward", email: "mail@test.dev", lastLogin: null },
    }));

    // Act
    const wrapper = mount(CoalesceExample);
    await flushPromises();

    // Assert
    expect(wrapper.text()).toMatch("Editing User ID: 8F9B1EF2-E5D1-467D-9E8D-1C0336BCE684");
    expect(document.title).toMatch("Squidward");
    expect(wrapper.findComponent(VTextField).vm.modelValue).toBe("Squidward");
  });
});
